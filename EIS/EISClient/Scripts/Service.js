function Service() {

    this.IsFirstTime = function () {
        if (localStorage["sessionKey"]) {
            return false;
        } else {
            return true;
        }
    }

    this.Login = function (password, callback) {
        var passwordKey = Sha1.hash(password);
        $.get("Services/LoginService.ashx", { key: passwordKey })
         .done(function (data) {
             callback(data);
         });
     }

     this.SaveKey = function (key) {
         localStorage["sessionKey"] = key;
     }

     this.SaveLoginPattern = function (sequence) {
         localStorage["pattern"] = sequence;
     }

     this.CheckPattern = function (pattern) {
         var storedPattern = localStorage["pattern"];
         if (storedPattern && storedPattern.length) {
             storedPattern = JSON.parse("["+storedPattern+"]");
             return this.ComparePattern(storedPattern, pattern);
         } else {
             return false;
         }
     }

     this.ComparePattern = function (pattern1, pattern2) {
         if (pattern1.length && pattern1.length == pattern2.length) {
             var allMatch = true;
             for (var i = 0; i < pattern1.length; i++) {
                 if (pattern1[i] !== pattern2[i]) {
                     allMatch = false;
                     break;
                 }
             }
             return allMatch;
         } else {
             return false;
         }
     }

}