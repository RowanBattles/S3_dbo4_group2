describe("HomePage tests", () => {
  it("Should go to Menupage", () => {
    /* ==== Generated with Cypress Studio ==== */
    cy.visit("http://localhost:5173/");
    cy.get(".rounded-md").click();
    /* ==== End Cypress Studio ==== */
  });
  it("Should go the DetailsPage when clicking an Item", () => {
    /* ==== Generated with Cypress Studio ==== */
    cy.visit("http://localhost:5173/");
    cy.get(".rounded-md").click();
    /* ==== End Cypress Studio ==== */
    /* ==== Generated with Cypress Studio ==== */
    cy.get('[href="/details/18"] > .bg-white > .w-64').click();
    /* ==== End Cypress Studio ==== */
  });
});
