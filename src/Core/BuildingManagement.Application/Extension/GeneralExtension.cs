namespace BuildingManagement.Application.Extension
{
    public static class GeneralExtension
    {
        public static T ToCreateMessage<T>(this T response, Guid id) where T : class
        {
            var messageProp = typeof(T).GetProperty("Message");
            if (messageProp is not null && messageProp.CanWrite)
            {
                messageProp.SetValue(response, $"{id} ID'si ile oluşturuldu.");
            }

            return response;
        }

        public static T ToUpdateMessage<T>(this T response, Guid id) where T : class
        {
            var messageProp = typeof(T).GetProperty("Message");
            if (messageProp is not null && messageProp.CanWrite)
            {
                messageProp.SetValue(response, $"{id} ID'li kayıt güncellendi.");
            }

            return response;
        }

        public static T ToDeleteMessage<T>(this T response, Guid id) where T : class
        {
            var messageProp = typeof(T).GetProperty("Message");
            if (messageProp is not null && messageProp.CanWrite)
            {
                messageProp.SetValue(response, $"{id} ID'li kayıt silindi.");
            }

            return response;
        }
    }
}
