// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Bot.Builder.AI.QnA;

namespace QnABotWithMSI.Contracts
{
    public interface IBotServices
    {
        IQnAMakerClient QnAMakerService { get; }
    }
}
