namespace VieJSLearning.Dal.Entities
{
    public class UserEntity: BaseEntity
    {
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
    }
}
