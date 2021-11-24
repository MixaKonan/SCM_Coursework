import csv
import matplotlib.pyplot as plt


def get_values(filename: str) -> list[list]:

    x_values = []
    y_values = []

    with open(filename, 'r') as values_file:
        reader = csv.reader(values_file, delimiter=';')
        for row in reader:
            x_values.append(float(row[0]))
            y_values.append(float(row[1]))

    return [x_values, y_values]

my_sin_values = get_values("E:\Studying\SCM_Coursework\Methods\my_sin.csv")
math_sin_values = get_values("E:\Studying\SCM_Coursework\Methods\math_sin.csv")
error_values = get_values("E:\Studying\SCM_Coursework\Methods\errors.csv")


plt.figure(0)
plt.grid()
plt.plot(my_sin_values[0], my_sin_values[1], label="Chebyshev coefficients")
plt.plot(math_sin_values[0], math_sin_values[1], label="Built-in sin(x) function")
plt.xlabel("Degrees (radian)")
plt.ylabel("Sin(x)")
plt.legend(fontsize=10)

plt.figure(1)
plt.grid()
plt.plot(error_values[0], error_values[1], label='Error')
plt.xlabel('Degrees (radian)')
plt.ylabel("Error")
plt.legend(fontsize=10)

plt.show()

