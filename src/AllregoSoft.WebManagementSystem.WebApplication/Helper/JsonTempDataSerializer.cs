using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.AspNetCore.Mvc.ViewFeatures.Infrastructure;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;

public class JsonTempDataSerializer : TempDataSerializer
{
    private readonly JsonSerializer _jsonSerializer = JsonSerializer.CreateDefault(new JsonSerializerSettings
    {
        TypeNameHandling = TypeNameHandling.All, // This may have security implications
    });

    public override byte[] Serialize(IDictionary<string, object> values)
    {
        var hasValues = values?.Count > 0;
        if (!hasValues)
            return Array.Empty<byte>();

        using var memoryStream = new MemoryStream();
        using var writer = new BsonDataWriter(memoryStream);

        _jsonSerializer.Serialize(writer, values);

        return memoryStream.ToArray();
    }

    public override IDictionary<string, object> Deserialize(byte[] unprotectedData)
    {
        using var memoryStream = new MemoryStream(unprotectedData);
        using var reader = new BsonDataReader(memoryStream);

        var tempDataDictionary = _jsonSerializer.Deserialize<Dictionary<string, object>>(reader) ?? new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);

        return tempDataDictionary;
    }
};