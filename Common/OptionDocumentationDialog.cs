using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Primitives;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QnABotWithMSI.Common
{
    public class OptionDocumentationDialog
    {
        public static async Task <DialogTurnResult> ShowOptions(WaterfallStepContext stepContext,CancellationToken cancellationToken )
        {
            var options = await stepContext.PromptAsync(
                nameof(TextPrompt),
                new PromptOptions
                {
                    Prompt = CreateSuggestedActions()
                },
                cancellationToken 
             );
            return options;
        }

        private static  Activity CreateSuggestedActions()
        {
            var reply = MessageFactory.Text("Mencioname el inconveniente que tienes");


            reply.SuggestedActions = new SuggestedActions()
            {
                Actions = new List<CardAction>()
                {
                    new CardAction(){Title= "Incidente", Value = "Incidente", Type=ActionTypes.ImBack},
                    new CardAction(){Title="Requerimiento", Value = "Reqierimiento", Type = ActionTypes.ImBack},
                    new CardAction(){Title="Autogestiion",Value = "Autogestion", Type= ActionTypes.ImBack}
                }
            };
            return reply;
        }
    }
}
