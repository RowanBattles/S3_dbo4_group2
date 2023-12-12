describe("sales", () => {
  it("Should go to Homepage", () => {
    /* ==== Generated with Cypress Studio ==== */
    cy.visit("http://localhost:5173/salespage");
    cy.get(".mb-10").should("have.text", "MenuMasters");
    /* ==== End Cypress Studio ==== */
  });
});
