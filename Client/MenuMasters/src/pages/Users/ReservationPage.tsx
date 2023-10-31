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
          <img
            src="https://joflow.nl/cdn/shop/products/Voorfoto_3bc2c4c8-01a8-4565-98f9-dadbbbea9e41_1200x1200.jpg?v=1657801731"
            className="w-4/12 object-contain"
          />
        </div>
      </div>
    </>
  );
}

export default ReservationPage;
