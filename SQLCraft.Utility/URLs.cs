
namespace SQLCraft.Utility
{
    public static class URLs
    {
        private const string Host = "https://localhost:7048/api";
        private const string HostIdentity = "https://localhost:7048";

        public static class ApplicationUser
        {
            public const string GET_APPLICATION_USER = $"{Host}/applicationUser/get";
            public const string GET_APPLICATION_USER_BY_EMAIL = $"{Host}/applicationUser/getByEmail";
            public const string UPDATE_APPLICATION_USER = $"{Host}/applicationUser/update";
            public const string DELETE_APPLICATION_USER = $"{Host}/applicationUser/delete";
            public const string GET_ALL_APPLICATION_USERS = $"{Host}/applicationUser/getAll";
            public const string SAVE_APPLICATION_USER = $"{Host}/applicationUser/save";
            public const string CHECK_IF_EMAIL_EXISTS = $"{Host}/applicationUser/checkIfEmailExists";
        }

        public static class DBSchema {
            public const string GET_DBSCHEMA = $"{Host}/dbSchema/get";
            public const string UPDATE_DBSCHEMA = $"{Host}/dbSchema/update";
            public const string DELETE_DBSCHEMA = $"{Host}/dbSchema/delete";
            public const string GET_ALL_DBSCHEMAS = $"{Host}/dbSchema/getAll";
            public const string SAVE_DBSCHEMA = $"{Host}/dbSchema/save";
        }

        public static class QuestionLevel
        {
            public const string GET_QUESTION_LEVEL = $"{Host}/questionLevel/get";
            public const string UPDATE_QUESTION_LEVEL = $"{Host}/questionLevel/update";
            public const string DELETE_QUESTION_LEVEL = $"{Host}/questionLevel/delete";
            public const string GET_ALL_QUESTION_LEVEL = $"{Host}/questionLevel/getAll";
            public const string SAVE_QUESTION_LEVEL = $"{Host}/questionLevel/save";
        }

        public static class Question
        {
            public const string GET_QUESTION = $"{Host}/question/get";
            public const string UPDATE_QUESTION = $"{Host}/question/update";
            public const string DELETE_QUESTION = $"{Host}/question/delete";
            public const string GET_ALL_QUESTION = $"{Host}/question/getAll";
            public const string SAVE_QUESTION = $"{Host}/question/save";
        }

        public static class QuestionCorrectAnswer
        {
            public const string GET_QUESTION_CORRECT_ANSWER = $"{Host}/questionCorrectAnswer/get";
            public const string UPDATE_QUESTION_CORRECT_ANSWER = $"{Host}/questionCorrectAnswer/update";
            public const string DELETE_QUESTION_CORRECT_ANSWER = $"{Host}/questionCorrectAnswer/delete";
            public const string GET_ALL_QUESTION_CORRECT_ANSWER = $"{Host}/questionCorrectAnswer/getAll";
            public const string SAVE_QUESTION_CORRECT_ANSWER = $"{Host}/questionCorrectAnswer/save";
        }

        public static class SQLQuery
        {
            public const string EXECUTE_QUERY = $"{Host}/sqlQuery/executeQuery";
        }

        public static class ChatGPT
        {
            public const string GET_ANSWER_ASYNC = $"{Host}/chatGPT/getAnswerAsync";
        }

        public static class Identity 
        {
            public const string REGISTER = $"{HostIdentity}/auth/register";
            public const string LOGIN = $"{HostIdentity}/auth/login";
            public const string REFRESH = $"{HostIdentity}/auth/refresh";
/*            public const string CONFIRM_EMAIL = $"{HostIdentity}/auth/confirmEmail";
            public const string RESEND_CONFIRMATION_EMAIL = $"{HostIdentity}/auth/resendConfirmationEmail";
            public const string FORGOT_PASSWORD = $"{HostIdentity}/auth/forgotPassword";
            public const string RESET_PASSWORD = $"{HostIdentity}/auth/resetPassword";
            public const string MANAGE_2FA = $"{HostIdentity}/auth/manage/2fa";*/
            public const string MANAGE_INFO = $"{HostIdentity}/auth/manage/info";
        }

        public static class Role
        {
            public const string GET_USER_ROLE = $"{Host}/Role/getUserRole";
            public const string GET_ROLES = $"{Host}/Role/getRoles";
            public const string ADD_ROLES = $"{Host}/Role/addRoles";
            public const string ADD_USER_ROLES = $"{Host}/Role/addUserRoles";
        }
    }
}
