namespace RedocPro.Descriptions
{
    public static class EndpointsDescriptions
    {
        public const string GetTransversalUserDataDescription = @"Some endpoint description goes here.";
        public const string RevokeRefreshTokenDescription = @"Some endpoint description goes here.";
        public const string GetUserProfileDescription = @"Some endpoint description goes here.";

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
    }
}
