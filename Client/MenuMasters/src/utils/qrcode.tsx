import React, { useEffect } from "react";
import QRCode from "react-qr-code";

interface QRCodeComponentProps {
  secretTafelnummer: number;
}

const QRCodeComponent: React.FC<QRCodeComponentProps> = ({
  secretTafelnummer,
}) => {
  useEffect(() => {
    const handleQRCodeClick = () => {
      const expirationTime = new Date();
      expirationTime.setTime(expirationTime.getTime() + 6 * 60 * 60 * 1000); // 6 hours

      document.cookie = `tafelNummer=${secretTafelnummer}; expires=${expirationTime.toUTCString()}`;
      window.location.href = `http://localhost:5173/`;
    };

    const qrCodeLink = document.getElementById(
      `qrCodeLink-${secretTafelnummer}`
    );

    if (qrCodeLink) {
      qrCodeLink.addEventListener("click", handleQRCodeClick);
    }

    return () => {
      if (qrCodeLink) {
        qrCodeLink.removeEventListener("click", handleQRCodeClick);
      }
    };
  }, [secretTafelnummer]);

  return (
    <div className="bg-light-gray text-center shadow-lg mx-4">
      <section className="mx-auto my-10 rounded-3xl p-4 w-80 bg-white">
        <div className="mb-6">
          <QRCode
            value={`http://localhost:5173/?tafelNummer=${secretTafelnummer}`}
            className="rounded-xl mx-auto"
          />
        </div>
        <h1 className="text-2xl text-center font-bold text-dark-blue mb-3">
          table: {secretTafelnummer}
        </h1>

        <p className="text-grayish-blue mb-5 leading-5">
          Scan the QR code to get your table number
        </p>
      </section>
    </div>
  );
};

// Create QRCode components for table 10 and table 15
const QRCodeTable10: React.FC = () => (
  <QRCodeComponent secretTafelnummer={10} />
);
const QRCodeTable15: React.FC = () => (
  <QRCodeComponent secretTafelnummer={15} />
);

// Display in a flex container with 3 items per row
const QRCodeGrid: React.FC = () => (
  <div className="flex flex-wrap justify-center">
    <QRCodeTable10 />
    <QRCodeTable15 />
    {/* Add more QRCode components as needed */}
  </div>
);

export { QRCodeGrid };
