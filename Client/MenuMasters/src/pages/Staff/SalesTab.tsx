import "../../styles/colorPalet.css";
import Tab from "../../components/Tab";

const SalesTab = () => {
  return (
    <>
      <div className="grid grid-cols-3 gray gap-5">
        <Tab />
        <Tab />
        <Tab />
        <Tab />
        <Tab />
        <Tab />
        <Tab />
      </div>
    </>
  );
};

export default SalesTab;
