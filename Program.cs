import tkinter as tk
import RPi.GPIO as GPIO


GPIO.setmode(GPIO.BCM)
LED_PINS = {
    "red": 17,
    "green": 27,
    "blue": 22
}
for pin in LED_PINS.values():
    GPIO.setup(pin, GPIO.OUT)
    GPIO.output(pin, GPIO.LOW)


def turn_on_led(color):
    for key, pin in LED_PINS.items():
        GPIO.output(pin, GPIO.LOW if key != color else GPIO.HIGH)


window = tk.Tk()
window.title("LED Controller")

selected_color = tk.StringVar()
selected_color.set("red")  # default value


tk.Radiobutton(window, text = "Red", variable = selected_color, value = "red",
               command = lambda: turn_on_led("red")).pack(anchor = tk.W)
tk.Radiobutton(window, text = "Green", variable = selected_color, value = "green",
               command = lambda: turn_on_led("green")).pack(anchor = tk.W)
tk.Radiobutton(window, text = "Blue", variable = selected_color, value = "blue",
               command = lambda: turn_on_led("blue")).pack(anchor = tk.W)


tk.Button(window, text = "Exit", command = window.quit).pack()


window.mainloop()


GPIO.cleanup()
