namespace DesafioEcommerce.Domain.Notifications
{
    public class Notification
    {
        public string Property { get; private set; }
        public string Value { get; private set; }

        public Notification(string property, string value)
        {
            Property = property;
            Value = value;
        }
    }
}
