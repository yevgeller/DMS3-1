using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DMS.Data;
using DMS.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace DMS.Pages.Person
{
    public class IndexModel : PageModel
    {
        private readonly DMS.Data.DMSDataContext _context;

        public IndexModel(DMS.Data.DMSDataContext context)
        {
            _context = context;
        }
        public IList<Models.Person> Person { get;set; }
        public PaginatedList<Models.Persons_List> Persons_List { get; set; }
        public string SortByName { get; set; }
        public string SortByActive { get; set; }
        public string SortByPersonType { get; set; }
        public string SortByAdditionalData { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; }
        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));
        public int Count { get; set; }
        public string PagerInfo
        {
            get
            {
                return $"Page {Persons_List.PageIndex} of {TotalPages} ({this.Count} record{(this.Count > 1 ? "s" : "")})";
            }
        }
        public int SelectedFilterPersonTypeId { get; set; }
        public bool SelectedFilterCheckedInactive { get; set; }
        public List<SelectListItem> PersonnelActiveStatusOptions { get; set; }
        public int SelectedFilterPersonnelActiveStatus { get; set; }

        public async Task OnPostFilteredAsync(string sortOrder, string currentFilter, string searchString, 
            int selectedFilterPersonTypeId, bool selectedFilterCheckedInactive, int selectedFilterPersonnelActiveStatus,
            int pageIndex)
        {
            await ProcessPageAsync(sortOrder, currentFilter, searchString, selectedFilterPersonTypeId,
                selectedFilterCheckedInactive, selectedFilterPersonnelActiveStatus, pageIndex);
        }
        public async Task OnGetAsync(string sortOrder, string currentFilter, string searchString, 
            int selectedFilterPersonTypeId, bool selectedFilterCheckedInactive, int selectedFilterPersonnelActiveStatus,
            int pageIndex)
        {
            await ProcessPageAsync(sortOrder, currentFilter, searchString, selectedFilterPersonTypeId, 
                selectedFilterCheckedInactive, selectedFilterPersonnelActiveStatus, pageIndex);
        }

        private async Task ProcessPageAsync(string sortOrder, string currentFilter, string searchString, 
            int selectedFilterPersonTypeId, bool selectedFilterCheckedInactive, int selectedFilterPersonnelActiveStatus, int pageIndex)
        {
            CurrentSort = sortOrder;
            SortByName = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "Name";
            SortByActive = sortOrder == "Is_Active" ? "is_active_desc" : "Is_Active";
            SortByPersonType = sortOrder == "Type" ? "type_desc" : "Type";
            SortByAdditionalData = sortOrder == "data" ? "data_desc" : "data";
            SelectedFilterCheckedInactive = selectedFilterCheckedInactive;
            SelectedFilterPersonnelActiveStatus = selectedFilterPersonnelActiveStatus;

            IQueryable<Persons_List> list = from p in _context.Persons_List select p;
            if (pageIndex == 0) pageIndex = 1;

            if (searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {
                list = list.Where(s => s.Name.ToLower().Contains(searchString.ToLower()) ||
                                        s.Person_Qualifier.ToLower().Contains(searchString.ToLower()));
            }

            if(selectedFilterPersonTypeId > 0)
            {
                list = list.Where(p => p.Person_Type_Id == selectedFilterPersonTypeId);
                SelectedFilterPersonTypeId = selectedFilterPersonTypeId;
            }

            if(selectedFilterPersonnelActiveStatus > 0)
            {
                switch (selectedFilterPersonnelActiveStatus)
                {
                    case 1:
                        list = list.Where(p => p.Is_Active == true);
                        break;
                    default:
                        list = list.Where(p => p.Is_Active == false);
                        break;
                }
            }

            switch (sortOrder)
            {
                case "name_desc":
                    list = list.OrderByDescending(p => p.Name);
                    break;
                case "Is_Active":
                    list = list.OrderByDescending(p => p.Is_Active); //yes before no
                    break;
                case "is_active_desc":
                    list = list.OrderBy(p => p.Is_Active);
                    break;
                case "Type":
                    list = list.OrderBy(p => p.Person_Type_Name);
                    break;
                case "type_desc":
                    list = list.OrderByDescending(p => p.Person_Type_Name);
                    break;
                case "data":
                    list = list.OrderBy(p => p.Person_Qualifier);
                    break;
                case "data_desc":
                    list = list.OrderByDescending(p => p.Person_Qualifier);
                    break;
                case "Name":
                default:
                    list = list.OrderBy(p => p.Name);
                    break;
            }

            Persons_List = await PaginatedList<Persons_List>.CreateAsync(list.AsNoTracking(), pageIndex, PageSize);

            this.Count = Persons_List.TotalRecordsCount;

            ViewData["Person_Types"] = new SelectList(_context.Person_Type.OrderBy(x=>x.Name), 
                "Person_Type_Id", "Name", selectedValue: selectedFilterPersonTypeId);
            //ViewData["Student_Id"] = new SelectList(_context.Student, "Student_Id", "Name");
            CreateYesNoOptionsList();
        }

        private void CreateYesNoOptionsList()
        {
            SelectListItem zero = new SelectListItem { Text = "-- Choose Personnel Status --", Value = "0" };
            SelectListItem one = new SelectListItem { Text = "Active Only", Value = "1" };
            SelectListItem two = new SelectListItem { Text = "Inactive Only", Value = "2" };
            PersonnelActiveStatusOptions = new List<SelectListItem> { zero, one, two };
        }
    }
}
