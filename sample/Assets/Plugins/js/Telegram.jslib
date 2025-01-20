mergeInto(LibraryManager.library, {
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

            var bufferSize = lengthBytesUTF8(launchParams.initDataRaw) + 1;
            var buffer = _malloc(bufferSize);
            stringToUTF8(launchParams.initDataRaw, buffer, bufferSize);
            return buffer
        } catch (error) {
            console.error('Error initializing app:', error);
        }
        return "";
    },
});
