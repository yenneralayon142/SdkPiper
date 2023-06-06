using Microsoft.Bot.Builder.Dialogs;
using QnABotWithMSI.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace QnABotWithMSI.Dialogs
{
    public class RootDialogSuplent : ComponentDialog
    {
        public RootDialogSuplent()
        {
            var waterfallStep = new WaterfallStep[]
            {
                ShowOptions,
                ShowDocumentation

            };
            AddDialog(new WaterfallDialog(nameof(WaterfallDialog),waterfallStep));
            AddDialog(new TextPrompt(nameof(TextPrompt)));
        }

        private async Task<DialogTurnResult> ShowDocumentation(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            //Mostrar Botones
            return await OptionDocumentationDialog.ShowOptions(stepContext, cancellationToken);

        }

        private async Task<DialogTurnResult> ShowOptions(WaterfallStepContext stepContext, CancellationToken cancellationToken)
        {
            var option = stepContext.Context.Activity.Text;
            switch(option) 
            {
                case "Incidente":
                    await stepContext.Context.SendActivityAsync("Aqui iran las opciones de Incidente", cancellationToken: cancellationToken);
                    break;
                case "Requerimiento":
                    await stepContext.Context.SendActivityAsync("Aqui iran las opciones de requerimiento", cancellationToken: cancellationToken);
                    break; 
                case "Autogestion":
                    await stepContext.Context.SendActivityAsync("Aqui iran las opciones de autogestion", cancellationToken: cancellationToken);
                    break;
                     
            }
            return await stepContext.EndDialogAsync(cancellationToken);
        }
    }
}
