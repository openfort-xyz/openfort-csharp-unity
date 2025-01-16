mergeInto(LibraryManager.library, {
    ShowAlert: function (message) {
        var returnStr = "bla" + UTF8ToString(message);
        var bufferSize = lengthBytesUTF8(returnStr) + 1;
        var buffer = _malloc(bufferSize);
        stringToUTF8(returnStr, buffer, bufferSize);
        return buffer;
    },
    InitTelegramApp: function () {
        const telegramSDK = telegramApps.sdk;
        try {
            // Retrieve launch parameters from Telegram
            const launchParams = telegramSDK.retrieveLaunchParams();
            console.log('Launch Parameters:', launchParams);

            // Example: Access user info
            const user = launchParams.initData.user;
            if (user) {
                console.log('User Info:', user.firstName, user.lastName);
            }

            // Notify Telegram that the app is ready
            // telegramSDK.initMiniApp();
            // console.log(miniApp);
            
            console.log("Buffer for", launchParams.initDataRaw);

            var bufferSize2 = lengthBytesUTF8(launchParams.initDataRaw) + 1;
            var buffer2 = _malloc(bufferSize2);
            stringToUTF8(launchParams.initDataRaw, buffer2, bufferSize2);
            return buffer2
        } catch (error) {
            console.error('Error initializing app:', error);
        }
        return "";
    },
});
