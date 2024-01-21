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
    <div className="p-80">
      <div id={`qrCodeLink-${secretTafelnummer}`}>
        <span>table: {secretTafelnummer}</span>
        <QRCode
          value={`http://localhost:5173/?tafelNummer=${secretTafelnummer}`}
        />
      </div>
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

export { QRCodeTable10, QRCodeTable15 };
