namespace RedocPro.Descriptions
{
    public static class EndpointsDescriptions
    {
        public const string GetTransversalUserDataDescription = @"Some endpoint description goes here.";
        public const string RevokeRefreshTokenDescription = @"Some endpoint description goes here.";
        public const string GetUserProfileDescription = @"Some endpoint description goes here.";
        public const string NethoneTransactionConfirm = @"Validates Nethone transaction integrity.";
        public const string NethoneTransaction = @"Process Nethone transaction.";
        public const string NethoneRecommendation = @"Process Nethone recommendation.";



        public const string UserValidation = @"This endpoint will validate if the user has any of the following states: 
											   <ul><li>NotRegistered = 0</li><li>PreRegistered = 1</li><li>Registered = 2</li>
											   <li>OTPRequired = 3</li><li>SoftBlock = 4</li><li>HardBlock = 5</li>
											   <li>CancelledAccount = 8</li><li>FirstLoginOxxo = 20</li></ul>";
        public const string ChangeUserProperty = @"This endpoint will change the property of the user.";
        public const string ChangeUserPassword = @"This endpoint will change the password of the user.";
        public const string AddTaCVersion = @"This endpoint will accept the TaC Version.";
        public const string GetLatestTaC = @"This endpoint will get the TaC Version.";

        public const string Response500 = @"- Unhandled error, is necesary validate the log.";
        public const string ResponsePost200 = @"Resource created successfully.";
        public const string ResponseGet200 = @"Information obtained correctly.";


        public const string UpdateUserProfileDescription = @"Updates the partial information of user.";
        public const string UpdateUserProfile200Description = @"The information is updated correctly";
        public const string UpdateUserProfile400Description = @"- The information is wrong (SPCI-400): the email provided is not valid.";
        public const string UpdateUserProfile401Description = @"" +
            "- Invalid token (SPCI-401-7): the given token is not valid.\n" +
            "- Invalid token (SPCI-401-8): the scope header is invalid.\n" +
            "- Nethone request a review (SPNE-401): review the user.\n" +
            "- Nethone refuse the request (SPNE-402): user refused.";
        public const string UpdateUserProfile409Description = @"- The email has been used. (SPCI-409-2): old email.";
        public const string UpdateUserProfile500Description = @"" +
            "- Loyalty User was not able to create (SPCI-500): if the user not exists in Loyalty.\n" +
            "- Unhandled error, is necesary validate the log.";

        public const string RecoveryUserPasswordDescription = @"Recovery an user's password, based on the requested data.";
        public const string RecoveryUserPassword200Description = @"The password was recovered successfully.";
        public const string RecoveryUserPassword401Description = @"" +
            "- Invalid token (SPCI-401-7): the given token is not valid.\n" +
            "- Invalid token (SPCI-401-8): the scope header is invalid.";
        public const string RecoveryUserPassword500Description = @"" +
            "- ChangeUserPassword User Not Found in Auth0 (SPCI-500): error. \n" +
            "- Invalid grant to recover password (SPCI-500): error. \n" +
            "- RecoveryUserPassword User Not Found in Auth0. (SPCI-500): error.\n" +
            "- Unhandled error, is necesary validate the log.\n";

        public const string CancelUserAccountDescription = @"Recovery an user's password, based on the requested data.";
        public const string CancelUserAccount200Description = @"The account is close correctly.";
        public const string CancelUserAccount401Description = @"" +
            "- The username or password is incorrect (SPCI-401-1): incorrect data (wrong email or password).";
        public const string CancelUserAccount500Description = @"" +
            "- CancelUserAccount User Not Found in Auth0 (SPCI-500): error.\n" +
            "- CancelUserAccount invalid grant.(SPCI-500): error.\n" +
            "- Generic error from Auth0 Service.(SPCI-500): error.\n" +
            "- Unhandled error, is necesary validate the log.";
        public const string TokenValidatorDescription = @"validates that the token sent is correct";

        public const string LoginDescription = @"Validates if the user has permissions to log in.";
        public const string Login401Description = @"The username or password is incorrect (SPCI-401-1).";

        public const string SignupDescription = @"Creates a user if meets the validations.";
        public const string Signup400Description = @"" +
            "- The phone number is out of coverage (SPCI-400-1).\n" +
            "- The user must be on legal age (SPCI-400).";
        public const string Signup409Description = @"" +
            "- The phone number has been used (SPCI-409-1).\n" +
            "- The email has been used (SPCI-409-2).\n" +
            "- It is not possible to register the user by a conflict (SPCI-409-3).\n" +
            "- There is a procedure in progress, please try again (SPCI-409-4).";
        public const string Signup421Description = @"" +
            "- The account was created but it was not possible to obtain a valid token (SCPI-421-1).";

        public const string RefreshTokenDescription = @"Generates a new refresh token.";
        public const string RefreshToken401Description = @"" +
            "- The refresh token has al ready expired, back to login (SPCI-401-2).\n" +
            "- The refresh token is invalid, back to login (SPCI-401-3).";

    }
}
