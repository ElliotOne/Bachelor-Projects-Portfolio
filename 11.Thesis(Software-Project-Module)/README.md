# Handwritten Number Recognition Projects

## Introduction

This repository contains two handwritten number recognition projects implemented in Python: one for Persian and another for English numbers. The primary goal of these projects is to explore the practical application of neural networks in solving handwritten number recognition problems. The projects involve data collection, preparation, visualization, and the implementation of artificial intelligence models using machine learning techniques.

## Persian Handwritten Number Recognition Project

### Objective

The objective of the Persian Handwritten Number Recognition Project is to investigate the practical use of neural networks for recognizing handwritten Persian numbers. The project covers the step-by-step implementation of neural networks and emphasizes the significance of efficient implementation for accurate number recognition.

### Problem Definition

1. **Data Collection:** The dataset is gathered from the Hoda Dataset, where the data is stored in the .cdb file format. To make it compatible with sklearn, the `csv_exporter.py` script is employed to export images data to CSV files.

2. **Data Preparation:** The data is then prepared by combining the output of pixels.csv and labels.csv to create the training data for the Persian dataset.

3. **Data Visualization:** The data is visualized using histograms and matplotlib to gain insights into the distribution of numbers in the training set.

4. **Artificial Intelligence Modeling:** The core of the Persian Handwritten Number Recognition Project lies in the implementation of artificial intelligence models. The primary algorithm used for this task is the Multi-Layer Perceptron (MLP), a class of feedforward artificial neural networks. Additionally, Principal Component Analysis (PCA) is applied for feature extraction and dimensionality reduction.

### Neural Network Architecture

The MLP neural network is configured with the following parameters:

- **Solver:** LBFGS
- **Alpha:** 1e-5
- **Hidden Layer Sizes:** (3500,)
  
```python
from sklearn.neural_network import MLPClassifier

# Define input (X) and output (y) for training
y = PCtrain['label'][0:7500]
X = PCtrain.drop('label', axis=1)[0:7500]

# Initialize MLP Classifier
clf = MLPClassifier(solver='lbfgs', alpha=1e-5, hidden_layer_sizes=(3500,), random_state=1)

# Train the model
clf.fit(X, y)
```
### Feature Engineering using PCA

The PCA technique is employed for feature extraction. It reduces the dimensionality of the dataset, capturing the most critical information while minimizing loss.

```python
from sklearn.decomposition import PCA

# Define the number of components for PCA
pca = PCA(n_components=100)

# Fit and transform the training data
PCtrain = pd.DataFrame(pca.fit_transform(train.drop('label', axis=1)))
PCtrain['label'] = train['label']
```

### Model Evaluation
The trained MLP model is then evaluated using metrics such as classification report and confusion matrix:

```python
from sklearn import metrics

# Predictions on the test set
predicted = clf.predict(PCtrain.drop('label', axis=1)[7500:15000])
expected = PCtrain['label'][7500:15000]

print("Classification report for classifier %s:\n%s\n" % (clf, metrics.classification_report(expected, predicted)))
print("Confusion matrix:\n%s" % metrics.confusion_matrix(expected, predicted))
```

This configuration and application of the MLP algorithm along with PCA contribute to the successful recognition of handwritten Persian numbers in the dataset.

The result of the `classification_report` and `confusion_matrix` is visualized in the image below:

<img src="https://github.com/ElliotOne/Bachelor-Projects-Portfolio/blob/main/11.Thesis(Software-Project-Module)/Screenshots/persian-confusion-matrix.png" />

## English Handwritten Number Recognition Project

The English Handwritten Number Recognition Project follows a similar structure to the Persian project. The primary difference is the source of the dataset, which is pre-existing, and the specific details regarding data preparation and visualization.

The result of the `classification_report` and `confusion_matrix` is visualized in the image below:

<img src="https://github.com/ElliotOne/Bachelor-Projects-Portfolio/blob/main/11.Thesis(Software-Project-Module)/Screenshots/english-confusion-matrix.png" />
