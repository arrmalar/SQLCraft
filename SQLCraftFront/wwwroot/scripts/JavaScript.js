LoginFunctions = {
    StoreAccessToken: function (at)
    {
        sessionStorage.setItem("at", at);
    },

    GetAccessToken: function () {
        return sessionStorage.getItem("at");
    }
}