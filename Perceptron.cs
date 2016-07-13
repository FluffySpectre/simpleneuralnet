using System;

namespace SimpleNeuralNet
{
	public class Perceptron {
		private float[] weights;  // Array of weights for inputs
		private float c;          // learning constant

		// Perceptron is created with n weights and learning constant
		public Perceptron(int n, float c_) {
			weights = new float[n];
			// Start with random weights
			Random r = new Random ();
			for (int i = 0; i < weights.Length; i++) {
				weights[i] = r.Next(-1,1); 
			}
			c = c_;
		}

		// Return weights
		public float[] GetWeights() {
			return weights; 
		}

		// Function to train the Perceptron
		// Weights are adjusted based on "desired" answer
		public void Train(float[] inputs, int desired) {
			// Guess the result
			int guess = FeedForward(inputs);
			// Compute the factor for changing the weight based on the error
			// Error = desired output - guessed output
			// Note this can only be 0, -2, or 2
			// Multiply by learning constant
			float error = desired - guess;
			// Adjust weights based on weightChange * input
			for (int i = 0; i < weights.Length; i++) {
				weights[i] += c * error * inputs[i];         
			}
		}

		// Guess -1 or 1 based on input values
		public int FeedForward(float[] inputs) {
			// Sum all values
			float sum = 0;
			for (int i = 0; i < weights.Length; i++) {
				sum += inputs[i]*weights[i];
			}
			// Result is sign of the sum, -1 or 1
			return Activate(sum);
		}

		private int Activate(float sum) {
			if (sum > 0) return 1;
			else return -1; 
		}
	}
}

