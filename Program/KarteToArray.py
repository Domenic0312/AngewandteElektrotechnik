from PIL import Image
import os
import numpy as np
import pandas as pd 

Schrittweite = 4

my_path = os.path.dirname(__file__)
imagePath = my_path + "/Karte_RAW.png"

im = Image.open(imagePath)
rgb_im = im.convert('RGB')
width, height = rgb_im.size
width = int(width/Schrittweite)
height = int(height/Schrittweite)

print(width, height)
arr = np.zeros((height, width)) 

for i in range(0, width):
    for j in range(0, height):
        r, g, b = rgb_im.getpixel((i*Schrittweite, j*Schrittweite))
        if g>250 and r<20 and b<20:
            arr[j,i] = 1
        else:
            arr[j,i] = 0

arr = np.around(arr, decimals=0)
print(arr)

#Speichern
np.savetxt((my_path+"/karteSmall.csv"), arr, delimiter=';', fmt='% 4d')

print("Wenn Sie dies hier lesen koennen, dann ist das Programm erfolgreich durchgelaufen. Einen schoenen Tag wuenscht das Team von DomSoft")