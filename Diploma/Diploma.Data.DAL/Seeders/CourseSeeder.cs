using Diploma.Data.Entities.Linking;
using Diploma.Data.Entities.Main.Course;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Diploma.Data.DAL.Seeders
{
	public static class CourseSeeder
	{

		public static void Seed(ModelBuilder builer)
		{
			SeedLessons(builer);
			SeedCourses(builer);
			SeedCourseLessons(builer);
		}

		private static void SeedLessons(ModelBuilder builder)
		{
			builder.Entity<Lesson>().HasData(new List<Lesson>
			{
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000001"),
					Order = 1,
					Title = "Neural Network Definition",
					Text = "Neural networks are a set of algorithms, modeled loosely after the human brain, that are designed to recognize patterns. They interpret sensory data through a kind of machine perception, labeling or clustering raw input. The patterns they recognize are numerical, contained in vectors, into which all real-world data, be it images, sound, text or time series, must be translated. Neural networks help us cluster and classify.",
					ImageName = "gettyimages-636079026-1024x1024.jpg"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000002"),
					Order = 2,
					Title = "A Few Concrete Examples",
					Text = "Deep learning maps inputs to outputs. It finds correlations. It is known as a “universal approximator”, because it can learn to approximate an unknown function f(x) = y between any input x and any output y, assuming they are related at all (by correlation or causation, for example). In the process of learning, a neural network finds the right f, or the correct manner of transforming x into y, whether that be f(x) = 3x + 12 or f(x) = 9x - 0.1. Here are a few examples of what deep learning can do.",
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000003"),
					Order = 3,
					Title = "Neural Network Elements",
					Text = "Course 1, Lesson 3",
					ImageName = "ZB6H4HuF58VcMOWbdpcRxQ.png"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000004"),
					Order = 4,
					Title = "Key Concepts of Deep Neural Networks",
					Text = "With classification, deep learning is able to establish correlations between, say, pixels in an image and the name of a person. You might call this a static prediction. By the same token, exposed to enough of the right data, deep learning is able to establish correlations between present events and future events. It can run regression between the past and the future. The future event is like the label in a sense. Deep learning doesn’t necessarily care about time, or the fact that something hasn’t happened yet. Given a time series, deep learning may read a string of number and predict the number most likely to occur next."
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000005"),
					Order = 5,
					Title = "Example: Feedforward Networks & Backprop",
					Text = "The layers are made of nodes. A node is just a place where computation happens, loosely patterned on a neuron in the human brain, which fires when it encounters sufficient stimuli. A node combines input from the data with a set of coefficients, or weights, that either amplify or dampen that input, thereby assigning significance to inputs with regard to the task the algorithm is trying to learn; e.g. which input is most helpful is classifying data without error? These input-weight products are summed and then the sum is passed through a node’s so-called activation function, to determine whether and to what extent that signal should progress further through the network to affect the ultimate outcome, say, an act of classification. If the signals passes through, the neuron has been “activated.”"
				},
			});
			builder.Entity<Lesson>().HasData(new List<Lesson>
			{
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000006"),
					Order = 1,
					Title = "ANN",
					Text = "An ANN is based on a collection of connected units or nodes called artificial neurons, which loosely model the neurons in a biological brain. Each connection, like the synapses in a biological brain, can transmit a signal to other neurons. An artificial neuron that receives a signal then processes it and can signal neurons connected to it. ",
					ImageName = "zWzeMGyCc7KvGD9X8lwlnQ.png"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000007"),
					Order = 2,
					Title = "ANN implementations",
					Text = "In ANN implementations, the signal at a connection is a real number, and the output of each neuron is computed by some non-linear function of the sum of its inputs. The connections are called edges. Neurons and edges typically have a weight that adjusts as learning proceeds. The weight increases or decreases the strength of the signal at a connection. Neurons may have a threshold such that a signal is sent only if the aggregate signal crosses that threshold. Typically, neurons are aggregated into layers. Different layers may perform different transformations on their inputs. Signals travel from the first layer (the input layer), to the last layer (the output layer), possibly after traversing the layers multiple times. ",
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000008"),
					Order = 3,
					Title = "Approach",
					Text = "The original goal of the ANN approach was to solve problems in the same way that a human brain would. But over time, attention moved to performing specific tasks, leading to deviations from biology. ANNs have been used on a variety of tasks, including computer vision, speech recognition, machine translation, social network filtering, playing board and video games, medical diagnosis, and even in activities that have traditionally been considered as reserved to humans, like painting",
				},
			});
			builder.Entity<Lesson>().HasData(new List<Lesson>
			{
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000009"),
					Order = 1,
					Title = "About",
					Text = "As an effective method, an algorithm can be expressed within a finite amount of space and time, and in a well-defined formal language for calculating a function Starting from an initial state and initial input (perhaps empty), the instructions describe a computation that, when executed, proceeds through a finite number of well-defined successive states, eventually producing output and terminating at a final ending state. The transition from one state to the next is not necessarily deterministic; some algorithms, known as randomized algorithms, incorporate random input",
					ImageName = "1920px-TTL_npn_nand.svg.png"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000010"),
					Order = 2,
					Title = "Concept",
					Text = "The concept of algorithm has existed since antiquity. Arithmetic algorithms, such as a division algorithm, was used by ancient Babylonian mathematicians c. 2500 BC and Egyptian mathematicians c. 1550 BC.[10] Greek mathematicians later used algorithms in the sieve of Eratosthenes for finding prime numbers,[11] and the Euclidean algorithm for finding the greatest common divisor of two numbers. Arabic mathematicians such as Al-Kindi in the 9th century used cryptographic algorithms for code-breaking, based on frequency analysis.",
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000011"),
					Order = 3,
					Title = "History",
					Text = "The word algorithm itself is derived from the 9th-century Persian mathematician Muḥammad ibn Mūsā al-Khwārizmī, Latinized Algoritmi.[14] A partial formalization of what would become the modern concept of algorithm began with attempts to solve the Entscheidungsproblem (decision problem) posed by David Hilbert in 1928. Later formalizations were framed as attempts to define effective calculabilityor effective method. Those formalizations included the Gödel–Herbrand–Kleene recursive functions of 1930, 1934 and 1935, Alonzo Church's lambda calculus of 1936, Emil Post's Formulation 1 of 1936, and Alan Turing's Turing machines of 1936–37 and 1939. "
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000012"),
					Order = 4,
					Title = "Etymology",
					Text = "About 825, al-Khwarizmi wrote an Arabic language treatise on the Hindu–Arabic numeral system, which was translated into Latin during the 12th century under the title Algoritmi de numero Indorum. This title means Algoritmi on the numbers of the Indian, where Algoritmi was the translator's Latinization of Al-Khwarizmi's name. Al-Khwarizmi was the most widely read mathematician in Europe in the late Middle Ages, primarily through another of his books, the Algebra. In late medieval Latin, algorismus, English 'algorism', the corruption of his name, simply meant the decimal number system. In the 15th century, under the influence of the Greek word ἀριθμός 'number' (cf. 'arithmetic'), the Latin word was altered to algorithmus, and the corresponding English term 'algorithm' is first attested in the 17th century; the modern sense was introduced in the 19th century."
				},
			});
			builder.Entity<Lesson>().HasData(new List<Lesson>
			{
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000013"),
					Order = 1,
					Title = "Intro",
					Text = "Python is a popular programming language. It was created by Guido van Rossum, and released in 1991.",
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000014"),
					Order = 2,
					Title = "What can Python do?",
					Text = "Python can be used on a server to create web applications. Python can be used alongside software to create workflows. Python can connect to database systems. It can also read and modify files. Python can be used to handle big data and perform complex mathematics. Python can be used for rapid prototyping, or for production - ready software development.",
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000015"),
					Order = 3,
					Title = "Python Quickstart",
					Text = "Python is an interpreted programming language, this means that as a developer you write Python (.py) files in a text editor and then put those files into the python interpreter to be executed."
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000016"),
					Order = 4,
					Title = "The Python Command Line",
					Text = "To test a short amount of code in python sometimes it is quickest and easiest not to write the code in a file. This is made possible because Python can be run as a command line itself."
				},
			});
			builder.Entity<Lesson>().HasData(new List<Lesson>
			{
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000017"),
					Order = 1,
					Title = "About",
					Text = ".NET Framework (pronounced as dot net) is a software framework developed by Microsoft that runs primarily on Microsoft Windows. It includes a large class library called Framework Class Library (FCL) and provides language interoperability (each language can use code written in other languages) across several programming languages. Programs written for .NET Framework execute in a software environment (in contrast to a hardware environment) named the Common Language Runtime (CLR). The CLR is an application virtual machine that provides services such as security, memory management, and exception handling. As such, computer code written using .NET Framework is called managed code. FCL and CLR together constitute the .NET Framework. ",
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000018"),
					Order = 2,
					Title = "FCL",
					Text = "FCL provides the user interface, data access, database connectivity, cryptography, web application development, numeric algorithms, and network communications. Programmers produce software by combining their source code with .NET Framework and other libraries. The framework is intended to be used by most new applications created for the Windows platform. Microsoft also produces an integrated development environment for .NET software called Visual Studio. ",
					ImageName = "5.jpg"
				},
				new Lesson
				{
					Id = new Guid("00000000-0000-0000-0000-000000000019"),
					Order = 3,
					Title = "History",
					Text = "Microsoft began developing .NET Framework in the late 1990s, originally under the name of Next Generation Windows Services (NGWS), as part of the .NET strategy. By late 2000, the first beta versions of .NET 1.0 were released. In August 2000, Microsoft, and Intel worked to standardize Common Language Infrastructure (CLI) and C#. By December 2001, both were ratified Ecma International (ECMA) standards.[3][4] International Organisation for Standardisation (ISO) followed in April 2003. The current version of ISO standards are ISO/IEC 23271:2012 and ISO/IEC 23270:2006. While Microsoft and their partners hold patents for CLI and C#, ECMA and ISO require that all patents essential to implementation be made available under reasonable and non-discriminatory terms. The firms agreed to meet these terms, and to make the patents available royalty-free. However, this did not apply for the part of .NET Framework not covered by ECMA-ISO standards, which included Windows Forms, ADO.NET, and ASP.NET. Patents that Microsoft holds in these areas may have deterred non-Microsoft implementations of the full framework."
				},
			});
		}

		private static void SeedCourses(ModelBuilder builder)
		{
			builder.Entity<Course>().HasData(new Course
			{
				Id = new Guid("00000000-0000-0000-0000-000000000001"),
				Title = "A Beginner's Guide to Neural Networks and Deep Learning",
				Description = "Neural networks are a set of algorithms, modeled loosely after the human brain, that are designed to recognize patterns. They interpret sensory data through a kind of machine perception, labeling or clustering raw input. The patterns they recognize are numerical, contained in vectors, into which all real-world data, be it images, sound, text or time series, must be translated.",
				ImageName = "gettyimages-636079026-1024x1024.jpg"
			});
			builder.Entity<Course>().HasData(new Course
			{
				Id = new Guid("00000000-0000-0000-0000-000000000002"),
				Title = "Artificial neural network",
				Description = "Artificial neural networks (ANN) or connectionist systems are computing systems vaguely inspired by the biological neural networks that constitute animal brains. Such systems learn to perform tasks by considering examples, generally without being programmed with task-specific rules. For example, in image recognition, they might learn to identify images that contain cats by analyzing example images that have been manually labeled as cat or no cat and using the results to identify cats in other images. They do this without any prior knowledge of cats, for example, that they have fur, tails, whiskers and cat-like faces. Instead, they automatically generate identifying characteristics from the examples that they process. ",
				ImageName = "2.png"
			});
			builder.Entity<Course>().HasData(new Course
			{
				Id = new Guid("00000000-0000-0000-0000-000000000003"),
				Title = "Algorithms",
				Description = "In mathematics and computer science, an algorithm is a finite sequence of well-defined, computer-implementable instructions, typically to solve a class of problems or to perform a computation Algorithms are always unambiguous and are used as specifications for performing calculations, data processing, automated reasoning, and other tasks. ",
				ImageName = "Screen-Shot-2019-09-05-at-11.00.46-AM-1024x766.png"
			});
			builder.Entity<Course>().HasData(new Course
			{
				Id = new Guid("00000000-0000-0000-0000-000000000004"),
				Title = "Python",
				Description = "Learn Python",
				ImageName = "1200px-Python-logo-notext.svg.png"
			});
			builder.Entity<Course>().HasData(new Course
			{
				Id = new Guid("00000000-0000-0000-0000-000000000005"),
				Title = ".NET Framework",
				Description = "Course 3 Description",
				ImageName = "c-sharp-dot-net.png"
			});
		}

		private static void SeedCourseLessons(ModelBuilder builder)
		{
			builder.Entity<CourseLesson>().HasData(new List<CourseLesson>
			{
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000001"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000001")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000001"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000002")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000001"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000003")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000001"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000004")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000001"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000005")
				}
			});
			builder.Entity<CourseLesson>().HasData(new List<CourseLesson>
			{
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000002"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000006")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000002"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000007")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000002"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000008")
				}
			});
			builder.Entity<CourseLesson>().HasData(new List<CourseLesson>
			{
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000003"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000009")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000003"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000010")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000003"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000011")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000003"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000012")
				},
			});
			builder.Entity<CourseLesson>().HasData(new List<CourseLesson>
			{
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000004"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000013")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000004"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000014")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000004"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000015")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000004"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000016")
				},
			}); 
			builder.Entity<CourseLesson>().HasData(new List<CourseLesson>
			{
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000005"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000017")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000005"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000018")
				},
				new CourseLesson
				{
					CourseId = new Guid("00000000-0000-0000-0000-000000000005"),
					LessonId = new Guid("00000000-0000-0000-0000-000000000019")
				},
			});
		}
	}
}
