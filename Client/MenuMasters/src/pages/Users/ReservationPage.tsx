import ReservationForm from "../../components/ReservationForm";

function ReservationPage() {
  return (
    <>
      <div className="pt-20 px-40 h-screen">
        <div className="flex items-center justify-center mb-20">
          <hr className="w-2/5 h-1 my-5 border-none red" />
          <span className="absolute px-5 text-4xl text-gray-900 -translate-x-1/2 bg-white left-1/2">
            RESERVATION
          </span>
        </div>
        <p className="text-3xl font-semibold mb-10">Booking</p>
        <div className="flex justify-between gap-x-24">
          <ReservationForm />
        </div>
      </div>
    </>
  );
}

export default ReservationPage;
