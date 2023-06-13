namespace RedocPro.Descriptions
{
	public static class EndpointsDescriptions
	{
		public const string GetTransversalUserDataDescription = @"Some endpoint description goes here.";
		public const string RevokeRefreshTokenDescription = @"Some endpoint description goes here.";
		public const string GetUserProfileDescription = @"Some endpoint description goes here.";
		public const string UserValidation = @"This endpoint will validate if the user has any of the following states: 
											   <ul><li>NotRegistered = 0</li><li>PreRegistered = 1</li><li>Registered = 2</li>
											   <li>OTPRequired = 3</li><li>SoftBlock = 4</li><li>HardBlock = 5</li>
											   <li>CancelledAccount = 8</li><li>FirstLoginOxxo = 20</li></ul>";
		public const string ChangeUserProperty = @"This endpoint will change the property of the user.";
		public const string ChangeUserPassword = @"This endpoint will change the password of the user.";
        public const string AddTaCVersion = @"This endpoint will accept the TaC Version.";
        public const string GetLatestTaC = @"This endpoint will get the TaC Version.";
    }
}
