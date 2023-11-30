import DateField from "./ReservationFormFields/DateField";
import TimeField from "./ReservationFormFields/TimeField";
import PeopleField from "./ReservationFormFields/PeopleField";

function ReservationForm() {
  return (
    <div className="w-full">
      <div className="grid grid-cols-3 gap-5 w-full mb-5">
        <div>
          <p className="font-semibold">Date</p>
          <DateField />
        </div>
        <div>
          <p className="font-semibold">Time</p>
          <TimeField />
        </div>
        <div>
          <p className="font-semibold">People</p>
          <PeopleField />
        </div>
      </div>
      <div className="grid grid-cols-2 gap-5 w-full mb-5">
        <div>
          <p className="font-semibold">First name</p>
          <input className="border-black border-solid border rounded-md px-4 py-2 focus:outline-red w-full" />
        </div>
        <div>
          <p className="font-semibold">Last name</p>
          <input className="border-black border-solid border rounded-md px-4 py-2 focus:outline-red w-full" />
        </div>
        <div>
          <p className="font-semibold">Email</p>
          <input className="border-black border-solid border rounded-md px-4 py-2 focus:outline-red w-full" />
        </div>
        <div>
          <p className="font-semibold">Phone number</p>
          <input className="border-black border-solid border rounded-md px-4 py-2 focus:outline-red w-full" />
        </div>
      </div>
      <div className="w-full mb-5">
        <p className="font-semibold">Comments (optional)</p>
        <textarea className="border-black border-solid border rounded-md px-4 py-24 focus:outline-red w-full" />
      </div>
      <button className="red text-white w-full py-5 rounded-lg">
        Book a table
      </button>
    </div>
  );
}

export default ReservationForm;
