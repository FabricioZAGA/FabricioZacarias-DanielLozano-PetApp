using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ZGAF_DELR_EXAMEN_2P.Extensions
{
    public static class PetExtensions
    {
        //  Extensión para un task para poderlo invocar sin necesidad de await
        // recibe parámetro task por default,
        // recibe boolean para decirle si regresa al contexto
        // recibo una acción que se ejecuta cuando hay una excepción
        public static async void SaveFireAndForget(this Task task, bool returnToCallingContext, Action<Exception> onException = null)
        {
            try
            {
                await task.ConfigureAwait(returnToCallingContext);
            }
            catch (Exception ex) when (onException != null)
            {
                onException(ex);
            }
        }
    }
}
