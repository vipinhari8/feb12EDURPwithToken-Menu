﻿(function () {
    "use strict";
    angular
        .module("common.services")
        .factory("userProfile",
        userProfile)

    function userProfile() {
        var setProfile = function (data) {
            sessionStorage.setItem('accessToken', data.access_token);
            sessionStorage.setItem('tokentype', data.token_type);
            sessionStorage.setItem('expiration', data.expires_in);
            sessionStorage.setItem('userName', data.userName);
            sessionStorage.setItem('UniversityId', data.UniversityId);
            sessionStorage.setItem('userid', data.userid);
            sessionStorage.setItem('roleid', data.roleid);

        };

        var getProfile = function () {
            var profile = {
                isLoggedIn: sessionStorage.getItem('accessToken') != null,
                token: sessionStorage.getItem('accessToken'),
                tokentype: sessionStorage.getItem('tokentype'),
                expiration: sessionStorage.getItem('expiration'),
                userName: sessionStorage.getItem('userName'),
                UniversityId: sessionStorage.getItem('UniversityId'),
                userid: sessionStorage.getItem('userid'),
                roleid: sessionStorage.getItem('roleid')
            };
            return profile;
        };

        var getToken = function () {
            return sessionStorage.getItem('accessToken');
        };

        var getAuthHeaders = function () {
            var accesstoken = sessionStorage.getItem('accessToken');
            var authHeaders = {};
            if (accesstoken) {
                authHeaders.Authorization = 'Bearer ' + accesstoken;
            }
            return authHeaders;
        };
        var logout = function () {
            sessionStorage.removeItem('accessToken');
        };

        return {
            setProfile: setProfile,
            getProfile: getProfile,
            getToken: getToken,
            getAuthHeaders: getAuthHeaders,
            logout: logout
        }
    }
})();