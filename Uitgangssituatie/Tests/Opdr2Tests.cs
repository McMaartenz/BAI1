using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BAI
{
    [TestFixture]
    public class Opdr2Tests
    {
        [Test]
        public void Opdr2a_Queue50_01_SizeOk()
        {
            // Arrange
            int expected = 50;

            // Act
            Queue<int> queue = BAI_Afteken1.Opdr2aQueue50();
            int actual = queue.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void Opdr2a_Queue50_02_ContentsOk()
        {
            // Arrange

            // Act
            Queue<int> queue = BAI_Afteken1.Opdr2aQueue50();

            // Assert
            int expected = 1;
            while (queue.Count > 0)
            {
                int actual = queue.Dequeue();
                Assert.AreEqual(expected, actual);
                expected++;
            }
        }

        [TestCase("", "")]   // Leeg
        [TestCase("1 3 -11 123 737", "")]   // Geen delers van 4
        [TestCase("0 4 44 -20 120 4444", "4444 120 -20 44 4 0")]   // Allemaal delers van 4
        [TestCase("1 2 3 4 5 6 7 -8 9", "-8 4")]
        [TestCase("174 7 180 387 353 378 111 435 170 333 31 328 144 65 169 195 134 442 341 408 254 442 122 325 375 314 104 96 225 10 380 267 376 226 286 466 185 81 167 308 388 448 370 200 217 7 470 435 226 345 396 272 106 162 280 232 385 355 13 39 274 15 211 161 453 263 452 418 279 202 10 54 276 33 20 306 72 421 108 369 344 169 370 379 113 108 162 214 445 54 82 330 69 128 35 374 237 210 247 454 55 52 156 24 335 343 496 74 143 473 161 463 247 144 195 105 144 331 48 345 102 238 472 225 121 180 484 148 498 146 70 362 175 154 314 292 14 347 44 269 112 89 72 471 393 119 84 425 433 429 231 406 162 401 353 317 80 430 403 156 358 348 75 497 404 298 288 94 329 402 92 296 287 278 234 13 167 2 332 2 96 60 215 69 414 163 201 273 300 497 213 83 444 388 411 263 14 75 67 95 330 489 96 31 338 434 119 383 168 340 150 78 99 401 60 298 134 7 83 241 98 16 293 332 189 9 352 399 367 470 499 93 434 237 172 107 464 184 230 480 45 317 105 459 347 136 484 43 328 113 130 8 491 325 497 314 196 264 342 329 82 220 16 198 341 58 143 361 229 453 334 449 276 102 197 280 411 334 484 54 25 309 72 254 341 491 101 110 240 358 410 201 342 400 398 325 301 407 119 290",
            "400 240 72 484 280 276 16 220 264 196 8 328 484 136 480 184 464 172 352 332 16 60 340 168 96 388 444 300 60 96 332 296 92 288 404 348 156 80 84 72 112 44 292 148 484 180 472 48 144 144 496 24 156 52 128 108 344 108 72 20 276 452 232 280 272 396 200 448 388 308 376 380 96 104 408 144 328 180")]
        public void Opdr2b_StackFromQueue_01_ContentsOk(string input_str, string expected)
        {
            // Arrange
            Queue<int> queue = new Queue<int>();
            List<int> list = TestUtils.IntListFromString(input_str);
            foreach (int x in list)
            {
                queue.Enqueue(x);
            }

            // Act
            Stack<int> stack = BAI_Afteken1.Opdr2bStackFromQueue(queue);
            
            // Assert
            Assert.AreEqual(expected, TestUtils.EnumToString(stack));
        }

        [TestCase("")]
        [TestCase("1 3 -11 123 737")]
        [TestCase("0 4 44 -20 120 4444")]
        [TestCase("1 2 3 4 5 6 7 -8 9")]
        [TestCase("174 7 180 387 353 378 111 435 170 333 31 328 144 65 169 195 134 442 341 408 254 442 122 325 375 314 104 96 225 10 380 267 376 226 286 466 185 81 167 308 388 448 370 200 217 7 470 435 226 345 396 272 106 162 280 232 385 355 13 39 274 15 211 161 453 263 452 418 279 202 10 54 276 33 20 306 72 421 108 369 344 169 370 379 113 108 162 214 445 54 82 330 69 128 35 374 237 210 247 454 55 52 156 24 335 343 496 74 143 473 161 463 247 144 195 105 144 331 48 345 102 238 472 225 121 180 484 148 498 146 70 362 175 154 314 292 14 347 44 269 112 89 72 471 393 119 84 425 433 429 231 406 162 401 353 317 80 430 403 156 358 348 75 497 404 298 288 94 329 402 92 296 287 278 234 13 167 2 332 2 96 60 215 69 414 163 201 273 300 497 213 83 444 388 411 263 14 75 67 95 330 489 96 31 338 434 119 383 168 340 150 78 99 401 60 298 134 7 83 241 98 16 293 332 189 9 352 399 367 470 499 93 434 237 172 107 464 184 230 480 45 317 105 459 347 136 484 43 328 113 130 8 491 325 497 314 196 264 342 329 82 220 16 198 341 58 143 361 229 453 334 449 276 102 197 280 411 334 484 54 25 309 72 254 341 491 101 110 240 358 410 201 342 400 398 325 301 407 119 290")]
        public void Opdr2b_StackFromQueue_02_QueueBecomesEmpty(string input_str)
        {
            // Arrange
            Queue<int> queue = new Queue<int>();
            List<int> list = TestUtils.IntListFromString(input_str);
            foreach (int x in list)
            {
                queue.Enqueue(x);
            }
            int expected = 0;

            // Act
            Stack<int> stack = BAI_Afteken1.Opdr2bStackFromQueue(queue);
            int actual = queue.Count;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}