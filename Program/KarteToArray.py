from PIL import Image
import os
import numpy as np
import pandas as pd 

Schrittweite = 5

my_path = os.path.dirname(__file__)
imagePath = my_path + "/Karte_RAW.png"

np.set_printoptions(precision=3)

im = Image.open(imagePath)
rgb_im = im.convert('RGB')
width, height = rgb_im.size
width = int(width/Schrittweite)
height = int(height/Schrittweite)

print(width, height)
arr = np.zeros((width, height)) 

for i in range(0, width):
    for j in range(0, height):
        r, g, b = rgb_im.getpixel((i*5, j*5))
        if g>250 and r<50 and b<50:
            arr[i,j] = 1
            #print("habe was", i,j)
        else:
            arr[i,j] = 0

arr = np.around(arr, decimals=0)
print(arr)
np.savetxt((my_path+"/karteSmall.csv"), arr, delimiter=';', fmt='% 4d')

print("Wenn Sie dies hier lesen koennen, dann ist das Programm erfolgreich durchgelaufen. Einen schoenen Tag wuenscht das Team von DomSoft")