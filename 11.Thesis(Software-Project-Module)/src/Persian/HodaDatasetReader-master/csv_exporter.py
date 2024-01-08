from HodaDatasetReader import *
import os
import pandas as pd

fileDir = os.path.dirname(os.path.realpath('__file__'))

TRAIN_PATH = os.path.join(fileDir, '.\\DigitDB\\Train 60000.cdb')

X_train, Y_train = read_hoda_dataset(dataset_path=TRAIN_PATH,
                                    images_height=32,
                                    images_width=32,
                                    one_hot=False,
                                    reshape=True)

pd.DataFrame(X_train).to_csv("pixels.csv")
pd.DataFrame(Y_train).to_csv("labels.csv")