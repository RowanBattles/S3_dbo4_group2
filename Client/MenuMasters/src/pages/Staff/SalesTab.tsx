import Tab from "../../components/Tab";

const SalesTab = () => {
  return (
    <>
      <div className="gray h-screen">
        <div className="grid grid-cols-5">
          <Tab />
          <Tab />
          <Tab />
          <Tab />
          <Tab />
          <Tab />
          <Tab />
        </div>
      </div>
    </>
  );
};

export default SalesTab;
