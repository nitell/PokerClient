using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cygni.PokerClient.Communication
{
    public class MessageBuffer
    {
        private string halfReceivedMessage = String.Empty;
        private Queue<string> messageStrings = new Queue<string>();
        private string delimiter;

        public MessageBuffer(string delimiter)
        {
            this.delimiter = delimiter;
        }

        public void Input(string input)
        {

            //if the input does not end with delimiter, its a half-received message that was cut in half
            //we store it, and prepend it to next input
            var str = halfReceivedMessage + input;
            var messages = str.Split(new[] { delimiter }, StringSplitOptions.RemoveEmptyEntries).ToList();
            if (!str.EndsWith(delimiter))
            {
                if (messages.Any())
                {
                    halfReceivedMessage = messages.Last();
                    messages.RemoveAt(messages.Count - 1);
                }
                else
                {
                    halfReceivedMessage = string.Empty;
                }
            }
            else
            {
                halfReceivedMessage = string.Empty;
            }

            foreach (var s in messages)
                messageStrings.Enqueue(s);
        }

        public IEnumerable<string> ReadMessages()
        {
            while (messageStrings.Any())
                yield return messageStrings.Dequeue();
        }
    }
}
