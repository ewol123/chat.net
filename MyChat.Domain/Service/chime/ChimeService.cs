using MyChat.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyChat.Domain.Repository;
using MyChat.Domain.Error;
using Amazon.Chime;
using Amazon;
using Amazon.Chime.Model;
namespace MyChat.Domain.Service.chime
{
    public class ChimeService : IChimeService
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRepository _userRepository;

        private readonly AmazonChimeConfig config;
        private readonly AmazonChimeClient chime;

        public ChimeService(IUnitOfWork unitOfWork, IUserRepository userRepository)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;

            config = new AmazonChimeConfig()
            {
                RegionEndpoint = RegionEndpoint.USEast1
            };

            chime =  new AmazonChimeClient(config);

        }


        /**
         * Create a new chime meeting.
         * This video conference can be joined by others,
         * if they have the creator's meetingId
         */
        public async Task<CreateChimeMeetingResponse> CreateChimeMeeting(CreateChimeMeetingRequest payload)
        {
            try
            {
                var response = new CreateChimeMeetingResponse();

                MyChat.Domain.Model.User user = await _userRepository.FindById((Guid)payload.userIdentifier);

                if (user == null)
                {
                    throw new ApplicationError("CreateChimeMeeting.CreateChimeMeeting]", 1);
                 }

                //TODO: interface this so our domain doesn't depend on an external service.
                var meetingResponse = await chime.CreateMeetingAsync(
                    new CreateMeetingRequest() { 
                        ClientRequestToken = Guid.NewGuid().ToString(),
                        MediaRegion = "eu-west-2"
                    });

                var attendeeResponse = await chime.CreateAttendeeAsync(
                    new CreateAttendeeRequest()
                    {
                        MeetingId = meetingResponse.Meeting.MeetingId,
                        ExternalUserId = user.id.ToString()
                    });

                response.meetingResponse = meetingResponse;
                response.attendeeResponse = attendeeResponse;
                return response;
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        /**
         * Join an existing chime meeting.
         * Users can join to a video conference,
         * if they have the creator's meetingId
         */
        public async Task<JoinChimeMeetingResponse> JoinChimeMeeting(JoinChimeMeetingRequest payload)
        {
            try
            {
                var response = new JoinChimeMeetingResponse();

                MyChat.Domain.Model.User user = await _userRepository.FindById((Guid)payload.userIdentifier);

                if (user == null)
                {
                    throw new ApplicationError("[ChimeService.JoinChimeMeeting]", 1);
                }

                //TODO: interface this so our domain doesn't depend on an external service.
                var attendeeResponse = await chime.CreateAttendeeAsync(
                   new CreateAttendeeRequest()
                   {
                       MeetingId = payload.meetingId.ToString(),
                       ExternalUserId = user.id.ToString()
                   });


                response.attendeeResponse = attendeeResponse;

                return response;

            }
            catch (Exception e)
            {

                throw e;
            }
        }
    }
}
