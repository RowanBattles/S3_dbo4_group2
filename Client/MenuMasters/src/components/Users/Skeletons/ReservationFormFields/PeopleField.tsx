const PeopleField = () => {
  const options = [];

  for (let i = 1; i <= 8; i++) {
    options.push(
      <option key={i} value={i}>
        {i}
      </option>
    );
  }

  return (
    <div>
      <select className="border-black bg-white border-solid border rounded-md px-4 py-2 cursor-pointer focus:outline-red caret-transparent w-full">
        <option disabled selected value="">
          Select number of people
        </option>
        {options}
      </select>
    </div>
  );
};

export default PeopleField;
