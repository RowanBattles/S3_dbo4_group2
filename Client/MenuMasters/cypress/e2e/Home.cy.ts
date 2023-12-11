describe("HomePage tests", () => {
  it("Should go to Homepage", () => {
    /* ==== Generated with Cypress Studio ==== */
    cy.visit("http://localhost:5173/");
    cy.get(".mb-10").should("have.text", "MenuMasters");
    /* ==== End Cypress Studio ==== */
  });
});
