﻿using System;
using System.Collections.Generic;

static class SendScheduledMessages
{
    public static void Run()
    {
        List<MessagingLib.Message> messages = new List<MessagingLib.Message>();
        messages.Add(new MessagingLib.Message
            {
                to = "01000000001",
                from = "029302266",
                text = "한글 45자, 영자 90자 이하 입력되면 자동으로 SMS타입의 메시지가 추가됩니다."
            }
        );

        // 1만건까지 추가 가능, DateTime을 넣지 않으면 즉시 발송으로 전환됩니다!
        //MessagingLib.Response response = MessagingLib.SendMessagesDetail(messages, DateTime);
        MessagingLib.Response response = MessagingLib.SendMessagesDetail(messages, DateTime.Parse("2022-10-5"));
        if (response.StatusCode == System.Net.HttpStatusCode.OK)
        {
            Console.WriteLine("전송 결과");
            Console.WriteLine("Group Info:" + response.Data?.SelectToken("groupInfo"));
        }
        else
        {
            Console.WriteLine("Error Code:" + response.ErrorCode);
            Console.WriteLine("Error Message:" + response.ErrorMessage);
        }
    }
}
