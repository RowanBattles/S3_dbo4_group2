import React, { useEffect } from "react";
import QRCode from "react-qr-code";

const QRCodeComponent: React.FC = () => {
  // Your secret variable (tafelnummer)
  const secretTafelnummer = 15;

  useEffect(() => {
    // Set up the QR code link with the secretTafelnummer
    const qrCodeLink = document.getElementById("qrCodeLink");

    const handleQRCodeClick = () => {
      // Set the value in localStorage before redirecting
      localStorage.setItem("tafelNummer", secretTafelnummer.toString());

      // Redirect to the site
      window.location.href = `http://localhost:5173/`;
    };

    if (qrCodeLink) {
      qrCodeLink.addEventListener("click", handleQRCodeClick);
    }

    // Cleanup event listener on component unmount
    return () => {
      if (qrCodeLink) {
        qrCodeLink.removeEventListener("click", handleQRCodeClick);
      }
    };
  }, [secretTafelnummer]);

  return (
    <div className="p-80">
      {/* Display the QR code with a link */}
      <div id="qrCodeLink">
        <QRCode
          value={`http://localhost:5173/?tafelNummer=${secretTafelnummer}`}
        />
      </div>
    </div>
  );
};

export default QRCodeComponent;
