import Tab from "../../components/BarTab";

function BarPage() {
  return (
    <div className="gray h-screen p-10">
      <div className="grid gray gap-10 grid-cols-3">
        <Tab />
        <Tab />
        <Tab />
      </div>
    </div>
  );
}

export default BarPage;
