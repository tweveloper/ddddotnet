/************************************************************************************
 * AWUtil javascript utilities
 *  - AllregoSoft Web Management System Javascript Utility
 *  - fetch api header
 *  - localstorage get set
 *  - 
 * @author Kim Tae Woo
 * @version 1.0.0
 ************************************************************************************/
var AWUtil = (function () {
    'use strict';

    var _utils = {};

    /* Variables & Constants
    -------------------------------------------------------------------------
     */



    /* Public Functions
    -------------------------------------------------------------------------
     */

    _utils.headers = function (type) {
        return headers(type);
    }

    /**
     * 인증토큰을 가져온다
     */
    _utils.getToken = function () {
        return getToken();
    }

    /**
     * 인증토큰을 가져온다
     * @param awms_authorization_token - API 인증 토큰
     */
    _utils.setToken = function (awms_authorization_token) {
        setToken(awms_authorization_token);
    }

    /**
     * 객체의 empty 여부 체크
     * @param obj - 검사할 객체
     */
    _utils.isEmpty = function (obj) {
        return isEmpty(obj);
    };

    return init();


    /* Private Functions
    -------------------------------------------------------------------------
     */

    function headers(type) {
        const requestHeaders = new Headers();
        requestHeaders.append('authorization', `Bearer ${getToken()}`);

        switch (type) {
            case "json":
                requestHeaders.append('Content-Type', 'application/json');
                break;
        }
        console.log(`get headers : ${requestHeaders}`);
        return requestHeaders;
    }

    // empty check
    function isEmpty(obj) {
        return (obj == null || obj == undefined);
    }

    // get localStorage item
    function getToken() {
        return localStorage.getItem('awms-authorization-token');
    }

    // set localStorage item
    function setToken(awms_authorization_token) {
        localStorage.setItem('awms-authorization-token', awms_authorization_token)
    }

    // init
    function init() {
        console.info('AWUtil initialized.');
        return _utils;
    }
})();
