import { SetStateAction, useState } from "react";

const TimeField = () => {
  const [selectedTime, setSelectedTime] = useState("16:00");

  const timeOptions = [];
  let hours = 16;
  let minutes = 0;

  while (hours <= 22) {
    const timeString = `${hours.toString().padStart(2, "0")}:${minutes
      .toString()
      .padStart(2, "0")}`;
    timeOptions.push(timeString);

    minutes += 30;
    if (minutes === 60) {
      minutes = 0;
      hours += 1;
    }
  }

  const handleTimeChange = (e: {
    target: { value: SetStateAction<string> };
  }) => {
    setSelectedTime(e.target.value);
  };

  return (
    <div>
      <select
        value={selectedTime}
        onChange={handleTimeChange}
        className="border-black border-solid border rounded-md px-4 py-2 cursor-pointer focus:outline-red caret-transparent bg-white w-full"
      >
        {timeOptions.map((time) => (
          <option key={time} value={time}>
            {time}
          </option>
        ))}
      </select>
    </div>
  );
};

export default TimeField;
