    ###  query{
      customerPagedAndFilter(first: 2, where: { id: { eq: 43330 } }) {
        pageInfo {
          hasNextPage
          startCursor
          endCursor
        }
        edges {
          node {
            id
            name
            mortgages(
              searchMortage: {
                mortageAmount: 411051.1
                mortageDate: "2012-03-16 00:00:00.0000000"
              }
            ) {
              NewInterestRate
              amount
              interestRate
            }
            customerBankAccounts {
              accountNumber
              bankName
              customerId
              createdDate
            }
            loanRelationships {
              totalAmount
              totalFee
              amount
            }
            addresses {
              id
              street
              state
              city
            }
          }
        }
      }
    }

####
