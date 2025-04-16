function showHomeUsed() {
    document.getElementById("homeLogin").style.display = "none";
    document.getElementById("homeUsing").style.display = "none";
    document.getElementById("homeUsed").style.display = "block";
}
function showHomeUsing() {
    document.getElementById("homeLogin").style.display = "none";
    document.getElementById("homeUsing").style.display = "block";
    document.getElementById("homeUsed").style.display = "none";
}
function showHomeLogin() {
    document.getElementById("homeLogin").style.display = "block";
    document.getElementById("homeUsing").style.display = "none";
    document.getElementById("homeUsed").style.display = "none";
}
window.onload = function () {
    const state = document.getElementById("homeState")?.value;

    if (state === "login") {
        showHomeLogin();
    } else if (state === "using") {
        showHomeUsing();
    }
};
