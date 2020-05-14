using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ZGAF_DELR_EXAMEN_2P.Triggers
{
    class WeightTrigger : TriggerAction<Entry>
    {
        //private string _oldValue = string.Empty;

        protected override void Invoke(Entry sender)
        {
            int n;
            var isNumeric = int.TryParse(sender.Text, out n);
            if (string.IsNullOrWhiteSpace(sender.Text) || !isNumeric)
            {
                sender.Text = ""; //_oldValue;
            }
            else
            {
                if (n < 1)
                {
                    sender.Text = "1";
                }
                else if (n > 100)
                {
                    sender.Text = "100";
                }
            }
        }
    }
}
