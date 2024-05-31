using CommunityEventPlanner.Data;
using Microsoft.EntityFrameworkCore;

namespace CommunityEventPlanner.Pages
{
    public partial class Index
    {
        public bool ShowCreate { get; set; }
        public bool ShowEdit { get; set; }
        public int EditingId { get; set; }

        private EventDataContext? _context;
        public Event? NewEvent { get; set; }
        public Event? EventToUpdate { get; set; }
        public List<Event>? OurEvents { get; set; }

        protected override async Task OnInitializedAsync()
        {
            ShowCreate = false;
            await ShowEvents();
        }

        //------------------ Create ----------------///
        public void ShowCreateForm()
        {
            ShowCreate = true;
            NewEvent = new Event();
        }

        public async Task CreateNewEvent()
        {
            _context ??= await EventDataContextFactory.CreateDbContextAsync();

            if (NewEvent is not null)
            {
                _context.Events.Add(NewEvent);
                await _context.SaveChangesAsync();
            }

            ShowCreate = false;
            await ShowEvents();
        }

        //------------------ Read ----------------///

        public async Task ShowEvents()
        {
            _context ??= await EventDataContextFactory.CreateDbContextAsync();

            if (_context is not null)
            {
                OurEvents = await _context.Events.ToListAsync();
            }
        }

        //------------------ Update ----------------///

        public async Task ShowEditForm(Event ourEvent)
        {
            _context ??= await EventDataContextFactory.CreateDbContextAsync();

            if (_context is not null)
            {
                EventToUpdate = await _context.Events.FindAsync(ourEvent.Id);
                ShowEdit = true;
                EditingId = ourEvent.Id;
            }
        }

        public async Task UpdateEvent()
        {
            _context ??= await EventDataContextFactory.CreateDbContextAsync();

            if (EventToUpdate is not null)
            {
                _context.Events.Update(EventToUpdate);
                await _context.SaveChangesAsync();
            }
            ShowEdit = false;
            EditingId = 0;
            await ShowEvents();
        }

        //------------------ Navigation ----------------///

        public void NavigateToSignUp(int eventId)
        {
            EventSignUpService.SetEventId(eventId);
            NavigationManager.NavigateTo("/event-signup");
        }

        public void NavigateToEventRegistrations()
        {
            NavigationManager.NavigateTo("/event-registrations");
        }
    }
}