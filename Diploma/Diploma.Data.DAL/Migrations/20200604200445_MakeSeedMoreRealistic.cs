using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Diploma.Data.DAL.Migrations
{
    public partial class MakeSeedMoreRealistic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseLesson",
                keyColumns: new[] { "CourseId", "LessonId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000013") });

            migrationBuilder.DeleteData(
                table: "CourseLesson",
                keyColumns: new[] { "CourseId", "LessonId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000014") });

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Lessons",
                maxLength: 4000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(2000)",
                oldMaxLength: 2000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(300)",
                oldMaxLength: 300,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Description", "ImageName", "Title" },
                values: new object[] { "Neural networks are a set of algorithms, modeled loosely after the human brain, that are designed to recognize patterns. They interpret sensory data through a kind of machine perception, labeling or clustering raw input. The patterns they recognize are numerical, contained in vectors, into which all real-world data, be it images, sound, text or time series, must be translated.", "index.jpg", "A Beginner's Guide to Neural Networks and Deep Learning" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Artificial neural networks (ANN) or connectionist systems are computing systems vaguely inspired by the biological neural networks that constitute animal brains. Such systems learn to perform tasks by considering examples, generally without being programmed with task-specific rules. For example, in image recognition, they might learn to identify images that contain cats by analyzing example images that have been manually labeled as cat or no cat and using the results to identify cats in other images. They do this without any prior knowledge of cats, for example, that they have fur, tails, whiskers and cat-like faces. Instead, they automatically generate identifying characteristics from the examples that they process. ", "Artificial neural network" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Description", "ImageName", "Title" },
                values: new object[] { "In mathematics and computer science, an algorithm is a finite sequence of well-defined, computer-implementable instructions, typically to solve a class of problems or to perform a computation Algorithms are always unambiguous and are used as specifications for performing calculations, data processing, automated reasoning, and other tasks. ", "Screen-Shot-2019-09-05-at-11.00.46-AM-1024x766.png", "Algorithms" });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "Description", "ImageName", "Title" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), "Learn Python", "1200px-Python-logo-notext.svg.png", "Python" },
                    { new Guid("00000000-0000-0000-0000-000000000005"), "Course 3 Description", "c-sharp-dot-net.png", ".NET Framework" }
                });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ImageName", "Text", "Title" },
                values: new object[] { "gettyimages-636079026-1024x1024.jpg", "Neural networks are a set of algorithms, modeled loosely after the human brain, that are designed to recognize patterns. They interpret sensory data through a kind of machine perception, labeling or clustering raw input. The patterns they recognize are numerical, contained in vectors, into which all real-world data, be it images, sound, text or time series, must be translated. Neural networks help us cluster and classify.", "Neural Network Definition" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "ImageName", "Text", "Title" },
                values: new object[] { null, "Deep learning maps inputs to outputs. It finds correlations. It is known as a “universal approximator”, because it can learn to approximate an unknown function f(x) = y between any input x and any output y, assuming they are related at all (by correlation or causation, for example). In the process of learning, a neural network finds the right f, or the correct manner of transforming x into y, whether that be f(x) = 3x + 12 or f(x) = 9x - 0.1. Here are a few examples of what deep learning can do.", "A Few Concrete Examples" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "ImageName", "Title" },
                values: new object[] { "ZB6H4HuF58VcMOWbdpcRxQ.png", "Neural Network Elements" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "Text", "Title" },
                values: new object[] { "With classification, deep learning is able to establish correlations between, say, pixels in an image and the name of a person. You might call this a static prediction. By the same token, exposed to enough of the right data, deep learning is able to establish correlations between present events and future events. It can run regression between the past and the future. The future event is like the label in a sense. Deep learning doesn’t necessarily care about time, or the fact that something hasn’t happened yet. Given a time series, deep learning may read a string of number and predict the number most likely to occur next.", "Key Concepts of Deep Neural Networks" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "Text", "Title" },
                values: new object[] { "The layers are made of nodes. A node is just a place where computation happens, loosely patterned on a neuron in the human brain, which fires when it encounters sufficient stimuli. A node combines input from the data with a set of coefficients, or weights, that either amplify or dampen that input, thereby assigning significance to inputs with regard to the task the algorithm is trying to learn; e.g. which input is most helpful is classifying data without error? These input-weight products are summed and then the sum is passed through a node’s so-called activation function, to determine whether and to what extent that signal should progress further through the network to affect the ultimate outcome, say, an act of classification. If the signals passes through, the neuron has been “activated.”", "Example: Feedforward Networks & Backprop" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "ImageName", "Text", "Title" },
                values: new object[] { "zWzeMGyCc7KvGD9X8lwlnQ.png", "An ANN is based on a collection of connected units or nodes called artificial neurons, which loosely model the neurons in a biological brain. Each connection, like the synapses in a biological brain, can transmit a signal to other neurons. An artificial neuron that receives a signal then processes it and can signal neurons connected to it. ", "ANN" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "Text", "Title" },
                values: new object[] { "In ANN implementations, the signal at a connection is a real number, and the output of each neuron is computed by some non-linear function of the sum of its inputs. The connections are called edges. Neurons and edges typically have a weight that adjusts as learning proceeds. The weight increases or decreases the strength of the signal at a connection. Neurons may have a threshold such that a signal is sent only if the aggregate signal crosses that threshold. Typically, neurons are aggregated into layers. Different layers may perform different transformations on their inputs. Signals travel from the first layer (the input layer), to the last layer (the output layer), possibly after traversing the layers multiple times. ", "ANN implementations" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "ImageName", "Text", "Title" },
                values: new object[] { null, "The original goal of the ANN approach was to solve problems in the same way that a human brain would. But over time, attention moved to performing specific tasks, leading to deviations from biology. ANNs have been used on a variety of tasks, including computer vision, speech recognition, machine translation, social network filtering, playing board and video games, medical diagnosis, and even in activities that have traditionally been considered as reserved to humans, like painting", "Approach" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "ImageName", "Text", "Title" },
                values: new object[] { "1920px-TTL_npn_nand.svg.png", "As an effective method, an algorithm can be expressed within a finite amount of space and time, and in a well-defined formal language for calculating a function Starting from an initial state and initial input (perhaps empty), the instructions describe a computation that, when executed, proceeds through a finite number of well-defined successive states, eventually producing output and terminating at a final ending state. The transition from one state to the next is not necessarily deterministic; some algorithms, known as randomized algorithms, incorporate random input", "About" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "ImageName", "Text", "Title" },
                values: new object[] { null, "The concept of algorithm has existed since antiquity. Arithmetic algorithms, such as a division algorithm, was used by ancient Babylonian mathematicians c. 2500 BC and Egyptian mathematicians c. 1550 BC.[10] Greek mathematicians later used algorithms in the sieve of Eratosthenes for finding prime numbers,[11] and the Euclidean algorithm for finding the greatest common divisor of two numbers. Arabic mathematicians such as Al-Kindi in the 9th century used cryptographic algorithms for code-breaking, based on frequency analysis.", "Concept" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "Text", "Title" },
                values: new object[] { "The word algorithm itself is derived from the 9th-century Persian mathematician Muḥammad ibn Mūsā al-Khwārizmī, Latinized Algoritmi.[14] A partial formalization of what would become the modern concept of algorithm began with attempts to solve the Entscheidungsproblem (decision problem) posed by David Hilbert in 1928. Later formalizations were framed as attempts to define effective calculabilityor effective method. Those formalizations included the Gödel–Herbrand–Kleene recursive functions of 1930, 1934 and 1935, Alonzo Church's lambda calculus of 1936, Emil Post's Formulation 1 of 1936, and Alan Turing's Turing machines of 1936–37 and 1939. ", "History" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "Text", "Title" },
                values: new object[] { "About 825, al-Khwarizmi wrote an Arabic language treatise on the Hindu–Arabic numeral system, which was translated into Latin during the 12th century under the title Algoritmi de numero Indorum. This title means Algoritmi on the numbers of the Indian, where Algoritmi was the translator's Latinization of Al-Khwarizmi's name. Al-Khwarizmi was the most widely read mathematician in Europe in the late Middle Ages, primarily through another of his books, the Algebra. In late medieval Latin, algorismus, English 'algorism', the corruption of his name, simply meant the decimal number system. In the 15th century, under the influence of the Greek word ἀριθμός 'number' (cf. 'arithmetic'), the Latin word was altered to algorithmus, and the corresponding English term 'algorithm' is first attested in the 17th century; the modern sense was introduced in the 19th century.", "Etymology" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "Order", "Text", "Title" },
                values: new object[] { 1, "Python is a popular programming language. It was created by Guido van Rossum, and released in 1991.", "Intro" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "Order", "Text", "Title" },
                values: new object[] { 2, "Python can be used on a server to create web applications. Python can be used alongside software to create workflows. Python can connect to database systems. It can also read and modify files. Python can be used to handle big data and perform complex mathematics. Python can be used for rapid prototyping, or for production - ready software development.", "What can Python do?" });

            migrationBuilder.InsertData(
                table: "Lessons",
                columns: new[] { "Id", "ImageName", "Order", "Text", "Title" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000019"), null, 3, "Microsoft began developing .NET Framework in the late 1990s, originally under the name of Next Generation Windows Services (NGWS), as part of the .NET strategy. By late 2000, the first beta versions of .NET 1.0 were released. In August 2000, Microsoft, and Intel worked to standardize Common Language Infrastructure (CLI) and C#. By December 2001, both were ratified Ecma International (ECMA) standards.[3][4] International Organisation for Standardisation (ISO) followed in April 2003. The current version of ISO standards are ISO/IEC 23271:2012 and ISO/IEC 23270:2006. While Microsoft and their partners hold patents for CLI and C#, ECMA and ISO require that all patents essential to implementation be made available under reasonable and non-discriminatory terms. The firms agreed to meet these terms, and to make the patents available royalty-free. However, this did not apply for the part of .NET Framework not covered by ECMA-ISO standards, which included Windows Forms, ADO.NET, and ASP.NET. Patents that Microsoft holds in these areas may have deterred non-Microsoft implementations of the full framework.", "History" },
                    { new Guid("00000000-0000-0000-0000-000000000016"), null, 4, "To test a short amount of code in python sometimes it is quickest and easiest not to write the code in a file. This is made possible because Python can be run as a command line itself.", "The Python Command Line" },
                    { new Guid("00000000-0000-0000-0000-000000000018"), "5.jpg", 2, "FCL provides the user interface, data access, database connectivity, cryptography, web application development, numeric algorithms, and network communications. Programmers produce software by combining their source code with .NET Framework and other libraries. The framework is intended to be used by most new applications created for the Windows platform. Microsoft also produces an integrated development environment for .NET software called Visual Studio. ", "FCL" },
                    { new Guid("00000000-0000-0000-0000-000000000015"), null, 3, "Python is an interpreted programming language, this means that as a developer you write Python (.py) files in a text editor and then put those files into the python interpreter to be executed.", "Python Quickstart" },
                    { new Guid("00000000-0000-0000-0000-000000000017"), null, 1, ".NET Framework (pronounced as dot net) is a software framework developed by Microsoft that runs primarily on Microsoft Windows. It includes a large class library called Framework Class Library (FCL) and provides language interoperability (each language can use code written in other languages) across several programming languages. Programs written for .NET Framework execute in a software environment (in contrast to a hardware environment) named the Common Language Runtime (CLR). The CLR is an application virtual machine that provides services such as security, memory management, and exception handling. As such, computer code written using .NET Framework is called managed code. FCL and CLR together constitute the .NET Framework. ", "About" }
                });

            migrationBuilder.InsertData(
                table: "CourseLesson",
                columns: new[] { "CourseId", "LessonId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000013") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000014") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000015") },
                    { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000016") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000017") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000018") },
                    { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000019") }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CourseLesson",
                keyColumns: new[] { "CourseId", "LessonId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000013") });

            migrationBuilder.DeleteData(
                table: "CourseLesson",
                keyColumns: new[] { "CourseId", "LessonId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000014") });

            migrationBuilder.DeleteData(
                table: "CourseLesson",
                keyColumns: new[] { "CourseId", "LessonId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000015") });

            migrationBuilder.DeleteData(
                table: "CourseLesson",
                keyColumns: new[] { "CourseId", "LessonId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000004"), new Guid("00000000-0000-0000-0000-000000000016") });

            migrationBuilder.DeleteData(
                table: "CourseLesson",
                keyColumns: new[] { "CourseId", "LessonId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000017") });

            migrationBuilder.DeleteData(
                table: "CourseLesson",
                keyColumns: new[] { "CourseId", "LessonId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000018") });

            migrationBuilder.DeleteData(
                table: "CourseLesson",
                keyColumns: new[] { "CourseId", "LessonId" },
                keyValues: new object[] { new Guid("00000000-0000-0000-0000-000000000005"), new Guid("00000000-0000-0000-0000-000000000019") });

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000015"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000016"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000017"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000018"));

            migrationBuilder.DeleteData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000019"));

            migrationBuilder.AlterColumn<string>(
                name: "Text",
                table: "Lessons",
                type: "nvarchar(2000)",
                maxLength: 2000,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 4000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Courses",
                type: "nvarchar(300)",
                maxLength: 300,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "CourseLesson",
                columns: new[] { "CourseId", "LessonId" },
                values: new object[,]
                {
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000013") },
                    { new Guid("00000000-0000-0000-0000-000000000003"), new Guid("00000000-0000-0000-0000-000000000014") }
                });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "Description", "ImageName", "Title" },
                values: new object[] { "Course 1 Description", "1.jpg", "Course 1" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "Description", "Title" },
                values: new object[] { "Course 2 Description", "Course 2" });

            migrationBuilder.UpdateData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "Description", "ImageName", "Title" },
                values: new object[] { "Course 3 Description", "3.jpg", "Course 3" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000001"),
                columns: new[] { "ImageName", "Text", "Title" },
                values: new object[] { "1.jpg", "Course 1, Lesson 1", "Lesson 1" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000002"),
                columns: new[] { "ImageName", "Text", "Title" },
                values: new object[] { "3.jpg", "Course 1, Lesson 2", "Lesson 2" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000003"),
                columns: new[] { "ImageName", "Title" },
                values: new object[] { "5.jpg", "Lesson 3" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000004"),
                columns: new[] { "Text", "Title" },
                values: new object[] { "Course 1, Lesson 4", "Lesson 4" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000005"),
                columns: new[] { "Text", "Title" },
                values: new object[] { "Course 1, Lesson 5", "Lesson 5" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000006"),
                columns: new[] { "ImageName", "Text", "Title" },
                values: new object[] { "2.png", "Course 2, Lesson 1", "Lesson 1" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000007"),
                columns: new[] { "Text", "Title" },
                values: new object[] { "Course 2, Lesson 2", "Lesson 2" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000008"),
                columns: new[] { "ImageName", "Text", "Title" },
                values: new object[] { "4.png", "Course 2, Lesson 3", "Lesson 3" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000009"),
                columns: new[] { "ImageName", "Text", "Title" },
                values: new object[] { "4.png", "Course 3, Lesson 1", "Lesson 1" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000010"),
                columns: new[] { "ImageName", "Text", "Title" },
                values: new object[] { "5.jpg", "Course 3, Lesson 2", "Lesson 2" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000011"),
                columns: new[] { "Text", "Title" },
                values: new object[] { "Course 3, Lesson 3", "Lesson 3" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000012"),
                columns: new[] { "Text", "Title" },
                values: new object[] { "Course 3, Lesson 4", "Lesson 4" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000013"),
                columns: new[] { "Order", "Text", "Title" },
                values: new object[] { 5, "Course 3, Lesson 5", "Lesson 5" });

            migrationBuilder.UpdateData(
                table: "Lessons",
                keyColumn: "Id",
                keyValue: new Guid("00000000-0000-0000-0000-000000000014"),
                columns: new[] { "Order", "Text", "Title" },
                values: new object[] { 6, "Course 3, Lesson 6", "Lesson 6" });
        }
    }
}
