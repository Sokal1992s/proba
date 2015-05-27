var firebaseRef = new Firebase('https://burning-fire-1723.firebaseio.com'); 
var wishRef = new Firebase('https://burning-fire-1723.firebaseio.com/WishList');
var auth = new FirebaseSimpleLogin(firebaseRef, function (error, user) {
    if (!error) {
        if (user) {
            App.load('LoginHome',user);
        }
    }
});