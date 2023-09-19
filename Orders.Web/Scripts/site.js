function RedirectOnSuccess (data) {
    console.log(data);
    window.location.replace(data.RedirectURL);
}