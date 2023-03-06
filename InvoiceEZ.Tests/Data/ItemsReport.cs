using System;
using InvoiceEZ.Domain.Models;

namespace InvoiceEZ.Tests.Data
{
    public static class ItemsReport
    {
        private static List<List<Invoice>> _invoicesInTheRangeTestCases = new List<List<Invoice>>();
        public static List<List<Invoice>> _invoicesOutOfRangeTestCases = new List<List<Invoice>>();

        public static List<List<Invoice>> InvoicesInTheRangeTestCases
        {
            get { return _invoicesInTheRangeTestCases; }
        }
        public static List<List<Invoice>> InvoicesOutOfRangeTestCases
        {
            get { return _invoicesOutOfRangeTestCases; }
        }

#region ItemsByInvoiceId
        private static Dictionary<int, List<InvoiceItem>> ItemsByInvoiceId = new Dictionary<int, List<InvoiceItem>>() {
                    {1, new List<InvoiceItem>(){
                        Shared.InvoiceItems["banana"]
                    }},
                    {2, new List<InvoiceItem>(){
                        Shared.InvoiceItems["banana"]
                    }},
                    {3, new List<InvoiceItem>(){
                        Shared.InvoiceItems["apple"]
                    }},
                    {4, new List<InvoiceItem>(){
                        Shared.InvoiceItems["pomegranate"]
                    } },
                    {5, new List<InvoiceItem>(){
                        Shared.InvoiceItems["banana"]
                    } },
                    {6, new List<InvoiceItem>(){
                        Shared.InvoiceItems["banana"]
                    } },
                    {7, new List<InvoiceItem>(){
                        Shared.InvoiceItems["apple"]
                    } },
                    {8, new List<InvoiceItem>(){
                        Shared.InvoiceItems["banana"]
                    } },
                    {9, new List<InvoiceItem>(){
                        Shared.InvoiceItems["apple"]
                    } },
                    {10, new List<InvoiceItem>(){
                        Shared.InvoiceItems["yourFavoriteFruit"]
                    } },
                    {11, new List<InvoiceItem>(){
                        Shared.InvoiceItems["banana"]
                    } },
                    {12, new List<InvoiceItem>(){
                        Shared.InvoiceItems["apple"]
                    } },
                    {13, new List<InvoiceItem>(){
                        Shared.InvoiceItems["banana"]
                    } },
                    {14, new List<InvoiceItem>(){
                        Shared.InvoiceItems["apple"]
                    } },
                    {15, new List<InvoiceItem>(){
                        Shared.InvoiceItems["banana"]
                    } },
                    {16, new List<InvoiceItem>(){
                        Shared.InvoiceItems["apple"]
                    } },
                    {17, new List<InvoiceItem>(){
                        Shared.InvoiceItems["yourFavoriteFruit"]
                    } },
                    {18, new List<InvoiceItem>(){
                        Shared.InvoiceItems["banana"]
                    } },
                    {19, new List<InvoiceItem>(){
                        Shared.InvoiceItems["apple"]
                    } },
                    {20, new List<InvoiceItem>(){
                        Shared.InvoiceItems["yourFavoriteFruit"]
                    }},
                    {21, new List<InvoiceItem>(){ Shared.InvoiceItems["banana"]}},
                    {22, new List<InvoiceItem>(){
                        Shared.InvoiceItems["pomegranate"]
                    } },
                    {23, new List<InvoiceItem>(){
                        Shared.InvoiceItems["banana"]
                    } },
                    {24, new List<InvoiceItem>(){
                        Shared.InvoiceItems["banana"]
                    } },
                    {25, new List<InvoiceItem>(){
                        Shared.InvoiceItems["banana"]
                    } },
                    {26,  new List<InvoiceItem>(){
                        Shared.InvoiceItems["apple"]
                    }},
                    {27, new List<InvoiceItem>(){
                        Shared.InvoiceItems["banana"]
                    } },
                    {28, new List<InvoiceItem>(){
                        Shared.InvoiceItems["apple"]
                    } },
                    {29, new List<InvoiceItem>(){
                        Shared.InvoiceItems["yourFavoriteFruit"]
                    } },
                    {30, new List<InvoiceItem>(){
                        Shared.InvoiceItems["apple"]
                    } },
                    {31, new List<InvoiceItem>(){
                        Shared.InvoiceItems["yourFavoriteFruit"]
                    } }
                };
        #endregion
        static ItemsReport()
        {
            InitInvoicesForReportTestCases();
        }
        private static void InitInvoicesForReportTestCases()
        {
#region InvoicesInOutRangeTestCases

            _invoicesInTheRangeTestCases = new List<List<Invoice>>(){
            new List<Invoice>(){
                new Invoice() {Id = 1, CreationDate = DateTime.Now.AddDays(-2),
                                },
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 2,
                    CreationDate = new DateTime(2022, 10, 5, 12, 30, 0),
                },
                new Invoice(){
                    Id = 3,
                    CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 4,
                    CreationDate = new DateTime(2015, 10, 5, 12, 30, 0),
                },
                new Invoice(){
                    Id = 5,
                    CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 6,
                    CreationDate = new DateTime(2018, 1, 3).AddMinutes(15),
                },
            new Invoice(){
                    Id = 7,
                    CreationDate = new DateTime(2018, 1, 3),
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 8,
                    CreationDate = new DateTime(2022, 10, 5, 12, 30, 0),
                },
                new Invoice(){
                    Id = 9,
                    CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                },
                new Invoice(){
                    Id = 10,
                    CreationDate = new DateTime(2018, 1, 1),
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 11,
                    CreationDate = new DateTime(2022, 10, 5, 12, 30, 0),
                },
                new Invoice(){
                    Id = 12,
                    CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 13,
                    CreationDate = new DateTime(2018, 1, 4, 12, 30, 0),
                },
                new Invoice(){
                    Id = 14,
                    CreationDate = new DateTime(2017, 10, 5, 12, 30, 0),
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 15,
                    CreationDate = new DateTime(2018, 1, 2, 12, 30, 0),
                },
                new Invoice(){
                    Id = 16,
                    CreationDate = new DateTime(2018, 1, 3),
                },
                new Invoice(){
                    Id = 17,
                    CreationDate = new DateTime(2018, 1, 5),
                }
            },
            new List<Invoice>(){
                new Invoice(){
                    Id = 18,
                    CreationDate = new DateTime(2018, 1, 3).AddMinutes(30),
                },
                new Invoice(){
                    Id = 19,
                    CreationDate = new DateTime(2018, 1, 4),
                },
                new Invoice(){
                    Id = 20,
                    CreationDate = new DateTime(2018, 1, 4).AddMinutes(30)
                }
            },
        };

            _invoicesOutOfRangeTestCases = new List<List<Invoice>>(){
                new List<Invoice>(){
                    new Invoice() {Id = 21, CreationDate = new DateTime(2017, 10, 5, 12, 30, 0)},
                },
                new List<Invoice>(){},
                new List<Invoice>(){
                    new Invoice(){
                        Id = 22,
                        CreationDate = new DateTime(2018, 1, 2, 12, 30, 0)
                    },
                    new Invoice(){
                        Id = 23,
                        CreationDate = new DateTime(2018, 1, 8, 12, 30, 0),
                    }
                },
                new List<Invoice>(){
                    new Invoice(){
                        Id = 24,
                        CreationDate = new DateTime(2018, 1, 3).AddMinutes(15)
                    },
                },
                new List<Invoice>(){},
                new List<Invoice>(){
                    new Invoice(){
                        Id = 25,
                        CreationDate = new DateTime(2018, 1, 3).AddMinutes(-15),
                    },
                    new Invoice(){
                        Id = 26,
                        CreationDate = new DateTime(2018, 1, 5).AddMinutes(15),
                    }
                },
                new List<Invoice>(){
                    new Invoice(){
                        Id = 27,
                        CreationDate = new DateTime(2018, 1, 1).AddMinutes(1),
                    }
                },
                new List<Invoice>(){
                    new Invoice(){
                        Id = 28,
                        CreationDate = new DateTime(2018, 1, 2).AddMinutes(-1),
                    },
                    new Invoice(){
                        Id = 29,
                        CreationDate = new DateTime(2018, 1, 3).AddMinutes(1),
                    }
                },
                new List<Invoice>(){
                    new Invoice(){
                        Id = 30,
                        CreationDate = new DateTime(2018, 1, 5),
                    },
                    new Invoice(){
                        Id = 31,
                        CreationDate = new DateTime(2018, 1, 25)
                    }
                },
            };
            AddItemToInvoiceItems(_invoicesInTheRangeTestCases);
            AddItemToInvoiceItems(_invoicesOutOfRangeTestCases);
            #endregion
        }

        private static void AddItemToInvoiceItems(List<List<Invoice>> invoices)
        {
            foreach (var list in invoices)
            {
                foreach (var invoice in list)
                {
                    ((List<InvoiceItem>)invoice.InvoiceItems).AddRange(ItemsByInvoiceId[invoice.Id]);
                }
            }
        }

#region ResultInvoiceExistTestCases
        public static List<Dictionary<string, long>> ResultInvoceExistTestCases = new List<Dictionary<string, long>>(){
        new Dictionary<string, long>{{"banana", Shared.InvoiceItems["banana"].Count}},
        new Dictionary<string, long>{{"banana", Shared.InvoiceItems["banana"].Count}},
        new Dictionary<string, long>{{"banana", Shared.InvoiceItems["banana"].Count}, {"pomegranate", Shared.InvoiceItems["pomegranate"].Count}},
        new Dictionary<string, long>{{"apple", Shared.InvoiceItems["apple"].Count}},
        new Dictionary<string, long>{{"apple", Shared.InvoiceItems["apple"].Count}, {"yourFavoriteFruit", Shared.InvoiceItems["yourFavoriteFruit"].Count}},
        new Dictionary<string, long>{{"apple", Shared.InvoiceItems["apple"].Count}},
        new Dictionary<string, long>{{"banana", Shared.InvoiceItems["banana"].Count}},
        new Dictionary<string, long>{{"apple", Shared.InvoiceItems["apple"].Count}, {"banana", Shared.InvoiceItems["banana"].Count}},
        new Dictionary<string, long>{{"apple", Shared.InvoiceItems["apple"].Count}, {"banana", Shared.InvoiceItems["banana"].Count}}
        };
        #endregion
#region DateRangeTestCases
        public static List<(DateTime?, DateTime?)> RangeInvoiceExistCases = new List<(DateTime?, DateTime?)>(){
                (null, null),
                (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("9999-12-31T23:59:59.9999999")),
                (DateTime.Parse("0001-01-01T00:00:00.0000000"), DateTime.Parse("9999-12-31T23:59:59.9999999")),
                (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("2018-01-03T00:00:00.0000000")),
                (DateTime.Parse("0001-01-01T00:00:00.0000000"), DateTime.Parse("2018-01-01T00:00:00.0000000")),
                (null, DateTime.Parse("2018-01-01T00:00:00.0000000")),
                (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("2018-01-05T00:00:00.0000000")),
                (DateTime.Parse("2018-01-02T00:00:00.0000000"), DateTime.Parse("2018-01-03T00:00:00.0000000")),
                (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("2018-01-04T00:00:00.0000000"))
            };
        public static List<(DateTime?, DateTime?)> RangeNoInvoiceCases = new List<(DateTime?, DateTime?)>(){
                (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("9999-12-31T23:59:59.9999999")),
                (null, null),
                (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("2018-01-04T00:00:00.0000000")),
                (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("2018-01-03T00:00:00.0000000")),
                (DateTime.Parse("0001-01-01T00:00:00.0000000"), DateTime.Parse("9999-12-31T23:59:59.9999999")),
                (DateTime.Parse("2018-01-03T00:00:00.0000000"), DateTime.Parse("2018-01-05T00:00:00.0000000")),
                (DateTime.Parse("0001-01-01T00:00:00.0000000"), DateTime.Parse("2018-01-01T00:00:00.0000000")),
                (DateTime.Parse("2018-01-02T00:00:00.0000000"), DateTime.Parse("2018-01-03T00:00:00.0000000")),
                (null, DateTime.Parse("2018-01-01T00:00:00.0000000")),
            };
        #endregion
    }
}

