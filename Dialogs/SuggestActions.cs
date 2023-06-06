using Microsoft.Bot.Builder;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Schema;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace QnABotWithMSI.Dialogs
{
    public class SuggestActions<T> : ActivityHandler where T: Dialog

    {
        protected readonly Dialog _dialog;
        protected readonly BotState _conversationState;
        protected readonly ILogger logger;


        public SuggestActions(T dialog, ConversationState conversationState, ILogger<SuggestActions<T>>logger)
        {
            _dialog = dialog;
            _conversationState = conversationState;
        }


        protected override async Task OnMessageActivityAsync(ITurnContext<IMessageActivity> turnContext, CancellationToken cancellationToken)
        {
            await _dialog.RunAsync(
            turnContext,
            _conversationState.CreateProperty<DialogState>(nameof(DialogState)),
            cancellationToken); ;

        }

        public override async Task OnTurnAsync(ITurnContext turnContext, CancellationToken cancellationToken = default)
        {
            await base.OnTurnAsync(turnContext, cancellationToken);
            await _conversationState.SaveChangesAsync(turnContext,false,cancellationToken);
        }



    }
}
