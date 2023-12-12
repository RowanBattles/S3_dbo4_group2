describe("template spec", () => {
  it("Should increase count in Cart", () => {
    /* ==== Generated with Cypress Studio ==== */
    cy.visit('http://localhost:5173/Menu');
    cy.get('.flex > a > div').click();
    cy.get('.w-56').click();
    cy.get('[href="/details/18"] > .bg-white > .w-64').click();
    cy.get('.mt-8 > .bg-primary').click();
    cy.get('a > div').click();
    cy.get('a > div').click();
    cy.get('.border-gray-100 > :nth-child(3)').click();
    cy.get('.border-gray-100 > .text-xl').should('have.text', '2');
    /* ==== End Cypress Studio ==== */
  });
});
