document.addEventListener("DOMContentLoaded", function () {
    var acceptButton = document.getElementById("cookie-accept-button");
    if (acceptButton) {
        acceptButton.addEventListener("click", function () {
            var date = new Date();
            date.setFullYear(date.getFullYear() + 1);

            document.cookie = "CookieConsent=true; expires=" + date.toUTCString() + "; path=/";
            var notification = document.getElementById("cookie-notification");
            if (notification) {
                notification.style.display = "none";
            }
        });
    }
});
