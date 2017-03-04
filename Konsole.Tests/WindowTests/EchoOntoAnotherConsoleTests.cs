﻿using NUnit.Framework;

namespace Konsole.Tests.WindowTests
{
    public class EchoOntoAnotherConsoleTests
    {
        [Test]
        public void When_echo_is_true_should_translate_all_writes_to_the_parent()
        {
            // the only reason this test is so important, because it's how we simulate writing to the real Console.
            var parent = new Window(0,0, 4, 4, false);
            var window = new Window(1, 1, 2, 2, true, parent);
            window.WriteLine("12");
            window.WriteLine("34");

            var expected = new[]
            {
                "    ",
                " 12 ",
                " 34 ",
                "    "
            };
            Assert.AreEqual(expected,parent.Buffer);
        }

        [Test]
        public void When_echo_is_true_should_translate_wrapped_lines_to_parent()
        {
            // the only reason this test is so important, because it's how we simulate writing to the real Console.
            var parent = new Window(0, 0, 4, 5, false);
            var window = new Window(1, 1, 2, 3, true, parent);
            window.WriteLine("12345");

            var expected = new[]
            {
                "    ",
                " 12 ",
                " 34 ",
                " 5  ",
                "    "
            };
            Assert.AreEqual(expected, parent.Buffer);
        }

    }
}